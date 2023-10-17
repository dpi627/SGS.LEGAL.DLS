using AutoMapper;
using LoadingIndicator.WinForms;
using Serilog;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Mapping;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SGS.LEGAL.DLS
{
    public partial class frmDunningLetter : Form
    {
        ////TODO: impersonator 帳號密碼可改為設定檔或資料庫取得
        //string impUserID = "efile_tw";
        //string impPassword = "OADApplicationPW!@#$%^02";

        private IMapper? _mapper;
        private readonly FormConfig? config;
        private readonly LongOperation? loader;

        private SYS_USER? CurrentUser => config?.CurrentUser;

        public frmDunningLetter() { }
        public frmDunningLetter(FormConfig config)
        {
            InitializeComponent();

            this.config = config;
            this.loader = new LongOperation(this);

            var configMap = new MapperConfiguration(cfg => cfg.AddProfile<DepositMapping>());
            _mapper = configMap.CreateMapper();

            dtpStartDate.Value = DateTime.Now.AddYears(-2);

            dgvBossDaily.AutoGenerateColumns = false;
            dgvBossDaily.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewCellStyle cellStyle = new();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBossDaily.DefaultCellStyle = cellStyle;

            DataGridViewCellStyle cellStyleAmt = new();
            cellStyleAmt.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBossDaily.DefaultCellStyle = cellStyle;
        }

        private void frmDunningLetter_Load(object sender, EventArgs e)
        {
            Utility.SetComboBox(ref cbbCompany, "COMPANY");
#if DEBUG
            dtpStartDate.Value = DateTime.Today.AddYears(-2);
            txtKeyword.Text = "710360";
            btnSearch_Click(sender, e);
#endif
        }

        private async Task GetImportDataAsync(BOSS_DAILY? model = default)
        {
            using (loader?.Start())
            {
                DataTable? data = await Task.Run(() =>
                {
                    using BossDailyService svc = new(CurrentUser, model);
                    return svc.Get();
                });
                dgvBossDaily.DataSource = data;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?:\d{4,}|[^\d]{2,})$";
            if (!Regex.IsMatch(txtKeyword.Text.Trim(), pattern))
            {
                MessageBox.Show($"關鍵字空白或異常{Environment.NewLine}{Environment.NewLine}Boss No 或 統編 至少需輸入四碼{Environment.NewLine}客戶名稱 至少需輸入兩個字", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("結束日期不可小於開始日期", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BOSS_DAILY model = new()
            {
                COMPANY = cbbCompany.SelectedValue.ToString(),
                KEYWORD = txtKeyword.Text,
                DATE_S = dtpStartDate.Value,
                DATE_E = dtpEndDate.Value
            };

            Utility.AddLog(
                OptLogType.Search,
                CurrentUser!,
                this.GetType().Name,
                model.ToString()
            );

            await GetImportDataAsync(model);
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void btnAbnormal_Click(object sender, EventArgs e)
        {
            using BossDailyService svc = new(CurrentUser, null);
            dgvBossDaily.DataSource = svc.GetAbnormal(chkOnlyTWD.Checked);
        }

        // 檢查 datatable 內是否包含多個客戶名稱 cst_nm
        private bool CheckIfMultiple(DataTable dt)
        {
            bool result = false;
            IEnumerable<string?>? query = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("CST_NM"))
                .Select(gr => gr.Key);

            if (query.Count() > 1)
            {
                string msg = string.Join(Environment.NewLine, query);
                MessageBox.Show($"包含多個客戶，請調整搜尋條件{Environment.NewLine}{Environment.NewLine}{msg}", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = true;
            }

            return result;
        }

        private async void btnNTF_Click(object sender, EventArgs e)
        {
            Log.Information($"dunnung letter {Ulid.NewUlid()}");
            await CreateLetterAsync("NTF.docx");
        }

        private async void btnDUN_Click(object sender, EventArgs e)
        {
            await CreateLetterAsync("DUN.docx", LetterType.DUN);
        }

        private async void btnDPS_Click(object sender, EventArgs e)
        {
            await CreateDepositAsync("DPS.docx");
        }

        /// <summary>
        /// 產生通知函、催收函
        /// 會在本機生成暫存檔，並預覽審核、列印等
        /// </summary>
        /// <param name="SourceFile">範本名稱</param>
        /// <param name="letterType">要產生的催款函類型</param>
        /// <returns></returns>
        private async Task CreateLetterAsync(string SourceFile, LetterType letterType = LetterType.NTF)
        {
            // 取得迴圈資料
            DataTable? loopData = (DataTable)dgvBossDaily.DataSource;

            if (CheckIfMultiple(loopData))
                return;

            // 計算總金額
            decimal total = 0;
            foreach (DataRow row in loopData.Rows)
            {
                total += Convert.ToDecimal(row["ACT_BALANCE"]);
            }

            // 取得第一筆資料
            DataRow r = loopData.Rows[0];
            // 建立客戶資料
            Customer cst = new()
            {
                CST_NM = r["CST_NM"] as string,
                CST_NO = r["CST_NO"] as string,
                BOSS_NO = r["BOSS_NO"] as string,
            };
            // 取得ID
            long bdID1st = long.Parse(r["BD_ID"].ToString()!);

            using frmInfoNTF? frmInfoNTF = new(cst, letterType);
            frmInfoNTF.ShowDialog();

            if (frmInfoNTF.DialogResult == DialogResult.Cancel)
                return;

            cst = frmInfoNTF._cst;

            // 取得公司資料
            using CompanyService? svcCom = new CompanyService(CurrentUser);
            COMPANY com = svcCom.Get(cbbCompany.SelectedValue.ToString()) ?? new COMPANY();

            // 提供客戶統編做為產出虛擬帳號使用
            //com.BANK_ACT = com.COM_CODE switch
            //{
            //    "SGS" or "CCS" => string.Format(com.BANK_ACT ?? "", cst.CST_NO),
            //    _ => com.BANK_ACT
            //};
            BankAccountInfo info = new()
            {
                COM_CODE = com.COM_CODE,
                CST_NO = cst.CST_NO,
                BOSS_NO = cst.BOSS_NO
            };
            using CustomerService? svcC = new CustomerService(CurrentUser);
            BankAccountResultModel? bank = svcC.GetBankAccountInfo(info);
            com.BANK_ACT = bank.BANK_ACT;

            // 建立通知函通用結構
            var comm = new CommonInfo(dtpEndDate.Value, total);

            // 所有信函、信封、收件回執等
            List<Letter> letters = new();

            // 建立XX函結構，設定範本路徑與輸出路徑等
            Letter letter = new(letterType, SourceFile, cst.CST_NM) { BD_ID_1ST = bdID1st };
            using (loader?.Start())
            {
                await Task.Run(() =>
                {
                    using DunningLetterService? svcL = new DunningLetterService(CurrentUser);
                    svcL.SetTemplate(letter.SourceFullPath)
                        .WriteDataOneTime(com, cst, comm, CurrentUser)
                        .WriteDataLoop(loopData, 2, "DI_ID")
                        .Save(letter.TempFullPath);
                });
            }
            letters.Add(letter);

            Utility.AddLog(OptLogType.Create, CurrentUser!, this.GetType().Name, letter.ToString());

            #region 催款函同時要產出信封與收件回執
            if (letterType == LetterType.DUN)
            {
                Letter rcv = new(letterType, "RCV.docx", cst.CST_NM, FileType.R) { BD_ID_1ST = bdID1st };
                await CreateSingleAsync(rcv, com, cst, comm, CurrentUser);
                letters.Add(rcv);
                Utility.AddLog(OptLogType.Create, CurrentUser!, this.GetType().Name, rcv.ToString());

                Letter env = new(letterType, "ENV.docx", cst.CST_NM, FileType.E) { BD_ID_1ST = bdID1st };
                await CreateSingleAsync(env, com, cst, comm, CurrentUser);
                letters.Add(env);
                Utility.AddLog(OptLogType.Create, CurrentUser!, this.GetType().Name, env.ToString());
            }
            #endregion

            // 預覽 PDF，不OK返回
            if (!PreviewPdf(letters)) return;

            // 催款函要直接列印，通知函不用，如最後沒有列印仍視為取消(返回，中斷作業)
            if (letterType == LetterType.DUN)
            {
                DialogResult result = await SetPrinterAsync(letters);
                if (result != DialogResult.OK) return;
            }

            string downloadPath = "";
            string additionalMessage = "";
            if (letterType == LetterType.NTF)
            {
                using FileService svc = new FileService(CurrentUser);
                downloadPath = svc.CopyFileToDownload(letter.TempFullPath);
                additionalMessage = $"{Environment.NewLine}{Environment.NewLine}檔案已經下載，將為您自動開啟路徑：{Environment.NewLine}{downloadPath}";
                Utility.AddLog(OptLogType.Download, CurrentUser!, this.GetType().Name, letter.ToString());
            }

            // 進行檔案處理
            await FileProcessAsync(letters);
            // 寫入紀錄，取得文件ID (僅取回信函的，信封或收件回執不管)
            string? docID = WriteDocLog(letters);

            // TODO: 信函ID回寫BOSS紀錄

            MessageBox.Show($"檔案產出成功：{Environment.NewLine}{letter.TargetFileName}{additionalMessage}", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (letterType == LetterType.NTF && !"".Equals(downloadPath))
            {
                Process.Start("explorer.exe", downloadPath);
            }
        }

        /// <summary>
        /// 顯示列印設定畫面，設定印表機與紙匣，進行列印。
        /// 如未執行(取消、中斷作業)，則刪除暫存檔
        /// </summary>
        /// <param name="letters">要列印的檔案集合</param>
        public async Task<DialogResult> SetPrinterAsync(List<Letter> letters)
        {
            using (loader?.Start())
            {
                return await Task.Run(() =>
                {
                    frmPrint print = new(config, letters);
                    DialogResult printResult = print.ShowDialog();
                    if (printResult != DialogResult.OK)
                    {
                        foreach (Letter l in letters)
                            File.Delete(l.TempFullPath);
                    }
                    return printResult;
                });
            }
        }

        /// <summary>
        /// 產生單一本機暫存檔，用於信封、收件回執等
        /// </summary>
        /// <param name="letter">信函或相關檔案資訊</param>
        /// <param name="datas">資料集合陣列，無限串接</param>
        /// <returns></returns>
        private async Task CreateSingleAsync(Letter letter, params object[] datas)
        {
            using (loader?.Start())
            {
                await Task.Run(() =>
                {
                    using DunningLetterService? svcL = new(CurrentUser);
                    svcL.SetTemplate(letter.SourceFullPath)
                        .WriteDataOneTime(datas)
                        .Save(letter.TempFullPath);
                });
            }
        }

        /// <summary>
        /// 產生存證信函
        /// </summary>
        /// <param name="SourceFile">存證信函範本</param>
        /// <param name="letterType">催款函類型，默認存證信函</param>
        /// <returns></returns>
        private async Task CreateDepositAsync(string SourceFile, LetterType letterType = LetterType.DPS)
        {
            // 取得迴圈資料
            DataTable? loopData = (DataTable)dgvBossDaily.DataSource;

            if (CheckIfMultiple(loopData))
                return;

            // 取得ID
            long bdID1st = long.Parse(loopData.Rows[0]["BD_ID"].ToString()!);

            // 計算總金額
            decimal total = 0;
            List<string> lstInvNo = new();
            foreach (DataRow row in loopData.Rows)
            {
                total += Convert.ToDecimal(row["ACT_BALANCE"]);
                lstInvNo.Add(row["INV_NO"] as string ?? "");
            }

            DepositContactParameter contactParam = new()
            {
                COM_CODE = cbbCompany.SelectedValue.ToString(),
                RCV_NM = loopData.Rows[0]["CST_NM"] as string
            };

            using frmInfoDPS? frmInfoDPS = new frmInfoDPS(contactParam);
            frmInfoDPS.ShowDialog();
            if (frmInfoDPS.DialogResult == DialogResult.Cancel)
                return;
            contactParam = frmInfoDPS.DepositContact;

            // 建立XX函結構，設定範本路徑與輸出路徑等
            Letter dps = new(letterType, SourceFile, contactParam.RCV_NM) { BD_ID_1ST = bdID1st };
            Letter rcv = new(letterType, "RCV.docx", contactParam.RCV_NM, FileType.R) { BD_ID_1ST = bdID1st };
            Letter env = new(letterType, "ENV.docx", contactParam.RCV_NM, FileType.E) { BD_ID_1ST = bdID1st };
            // 所有信函、信封、收件回執等
            List<Letter> letters = new() { dps, rcv, env };

            DepositParameter dpsParam = new()
            {
                AMT_NM = contactParam.AMT_NM,
                AMT = total, // 617085,
                LST_INV_NO = lstInvNo, // new List<string> { "EP33445623", "KD50300881" },
                TEL = CurrentUser.USER_TEL, // "02-22993279",
                EXT = CurrentUser.USER_TEL_EXT, //"1354",
                USR_NM = CurrentUser.USER_NM //"郭ｏ禎"
            };

            // 結構轉換，建立存證信函相關結構
            DepositInfo? info = _mapper.Map<DepositInfo>(dpsParam);
            DepositContactInfo? contact = _mapper.Map<DepositContactInfo>(contactParam);
            // 產生存證信函
            using (loader?.Start())
            {
                await Task.Run(() =>
                {
                    using DepositService svcD = new();
                    svcD.SetTemplate(dps.SourceFullPath)
                        .SetData(info, contact)
                        .Save(dps.TempFullPath);
                });
            }

            // 建立收件回執結構
            ReceiptModel? dataRcv = new ReceiptModel(
                contact.RCV_POST_CODE,
                contact.RCV_ADDR,
                contact.RCV_NM,
                contact.COM_POST_CODE,  //收件回執之收件地址一律用總公司地址資料
                contact.COM_ADDR,       //收件回執之收件地址一律用總公司地址資料
                contact.SND_NM,
                info.USR_NM,
                info.EXT
                );
            // 建立信封結構
            EnvelopeModel? dataEnv = new EnvelopeModel(
                contact.RCV_POST_CODE,
                contact.RCV_ADDR,
                contact.RCV_NM,
                info.USR_NM,
                info.TEL,
                info.EXT
                );

            // 產生收件回執、信封
            await CreateSingleAsync(rcv, dataRcv);
            await CreateSingleAsync(env, dataEnv);

            // 預覽 PDF，不OK返回
            if (!PreviewPdf(letters)) return;

            // 列印，如最後沒有列印仍視為取消(返回，中斷作業)
            DialogResult result = await SetPrinterAsync(letters);
            if (result != DialogResult.OK) return;

            // 進行檔案處理
            await FileProcessAsync(letters);

            // 寫入紀錄，取得文件ID
            string? docID = WriteDocLog(letters);

            MessageBox.Show($"{dps.TargetFileName}{Environment.NewLine}{Environment.NewLine}產生完成", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 處理檔案，使用特殊AD帳號
        /// </summary>
        /// <param name="letter">信函物件</param>
        private async Task FileProcessAsync(Letter letter)
        {
            using (loader?.Start())
            {
                await Task.Run(() =>
                {
                    // 建立檔案服務，帶入特殊AD帳號
                    using FileService svcF = new FileService(CurrentUser, config?.Impersonator);
                    svcF.SetTempFullPath(letter.TempFullPath)   // 設定暫存檔路徑
                        .SetBackupPath(letter.BackupPath)       // 設定備份路徑
                        .SetPublishPath(letter.TargetPath)      // 設定發佈路徑
                        .Publish();
                });
            }
        }
        /// <summary>
        /// 批次檔案處理
        /// </summary>
        /// <param name="letters">信函與相關檔案</param>
        private async Task FileProcessAsync(List<Letter> letters)
        {
            foreach (Letter letter in letters)
                await FileProcessAsync(letter);
        }

        /// <summary>
        /// 檢核一筆 PDF，回傳結果
        /// </summary>
        /// <param name="letter">信件或其他文件</param>
        /// <returns>審核結果</returns>
        private DialogResult OpenPdfViewer(Letter letter)
        {
            // 這種 using 寫法，不確定何時 dispose，手動避免無法刪除
            using frmPdfViewer frmPreview = new frmPdfViewer(letter, config);
            DialogResult result = frmPreview.ShowDialog();
            frmPreview.Dispose(); //手動Dispose
            return result;
        }
        /// <summary>
        /// 批次審閱 PDF
        /// </summary>
        /// <param name="letters">信函與相關文件</param>
        /// <returns>審核結果</returns>
        private bool PreviewPdf(List<Letter> letters)
        {
            bool IsApprove = true;
            // 單個文件檢視結果
            DialogResult result;
            // 所有文件檢視結果
            List<DialogResult> results = new List<DialogResult>();
            // 逐筆審核
            foreach (Letter letter in letters)
            {
                // 單筆檢視，紀錄結果
                result = OpenPdfViewer(letter);
                results.Add(result);
                // 如果結果不OK，就離開迴圈
                if (result == DialogResult.Cancel)
                    break;
            }
            // 如果包含一筆不OK(狀態取消)，就刪除所有暫存檔
            if (results.Contains(DialogResult.Cancel))
            {
                foreach (Letter letter in letters)
                    File.Delete(letter.TempFullPath);
                IsApprove = false;
            }

            return IsApprove;
        }

        /// <summary>
        /// 寫入單筆歷史紀錄，取得文件ID (ULID)
        /// </summary>
        /// <param name="letter">信函物件</param>
        /// <returns>文件ID(ULID)</returns>
        private string? WriteDocLog(Letter letter)
        {
            using DocLogService docLog = new(CurrentUser);
            string? docID = docLog.Add(new DOC_LOG()
            {
                BD_ID_1ST = letter.BD_ID_1ST,
                FIL_TYP = letter.FileType.ToString(),
                LET_TYP = letter.LetterType.ToString(),
                BAK_PATH = letter?.BackupFullPath
            });
            return docID;
        }
        /// <summary>
        /// 寫入多筆，取回第一個ID
        /// </summary>
        /// <param name="letters"></param>
        /// <returns>文件ID (應該就是信函ID，非其他種類文件，例如信封、收件回執)</returns>
        private string? WriteDocLog(List<Letter> letters)
        {
            List<string> ids = new List<string>();
            foreach (Letter letter in letters)
                ids.Add(WriteDocLog(letter) ?? "");
            return ids.FirstOrDefault();
        }

        private void cbbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvBossDaily.DataSource = null;
        }
    }
}