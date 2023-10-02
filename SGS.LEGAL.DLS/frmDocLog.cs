using AutoMapper;
using LoadingIndicator.WinForms;
using Serilog;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Mapping;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Parameter;
using SGS.LEGAL.DLS.Service;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.ViewModel;
using System.Diagnostics;
using u = SGS.LIB.Common.Utility;

namespace SGS.LEGAL.DLS
{
    public partial class frmDocLog : Form
    {
        private IMapper? _mapper;
        private readonly FormConfig? config;
        private readonly LongOperation? loader;

        private SYS_USER? CurrentUser => config?.CurrentUser;


        public frmDocLog() { }
        public frmDocLog(FormConfig config)
        {
            InitializeComponent();

            this.config = config;
            //this.loader = new LongOperation(this);

            var configMap = new MapperConfiguration(cfg => cfg.AddProfile<DocLogMapping>());
            _mapper = configMap.CreateMapper();

            dgvDocLog.AutoGenerateColumns = false;
            dgvDocLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewCellStyle cellStyle = new();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDocLog.DefaultCellStyle = cellStyle;

            dtpStartDate.Value = DateTime.Now.AddYears(-2);
        }

        private void frmDocLog_Load(object sender, EventArgs e)
        {
            Utility.SetComboBox(ref cbbCompany, "COMPANY", true, "(全部公司)");
            GetDocLog();
        }

        /// <summary>
        /// 取得搜尋條件
        /// </summary>
        private DocLogParameter GetParameter()
        {
            return new DocLogParameter()
            {
                COMPANY = cbbCompany.SelectedValue?.ToString()!,
                KEYWORD = txtKeyword.Text,
                START_DATE = dtpStartDate.Value, //DateTime.Now.AddDays(-7),
                END_DATE = dtpEndDate.Value, //DateTime.Now,
                CRT_USER = CurrentUser?.USER_ID
            };
        }

        private void GetDocLog()
        {
            // 搜尋條件轉換為 Info
            var info = _mapper.Map<DocLogInfo>(GetParameter());
            // 建立服務
            using DocLogService svc = new DocLogService(CurrentUser);
            // 取得資料 (帶入 Info，回傳為 ResultModel)
            var result = svc.Get(info);
            // 轉換為 ViewModel
            var dataSource = _mapper.Map<IList<DocLogViewModel>>(result);
            // 轉換為 DataTable (非必要，但 DataGridView 有時候設定 DataTable 比較好操作)
            dgvDocLog.DataSource = u.ToDataTable(dataSource);
        }

        /// <summary>
        /// 預覽檔案，判斷是否自動刪除
        /// </summary>
        /// <param name="letter">檔案相關資訊</param>
        /// <param name="isAutoDelete">自動刪除，預設否 (檔案留作快取避免重複下載)</param>
        private void ViewPdf(Letter letter, bool isAutoDelete = false)
        {
            Log.Information($"View Pdf");
            // 檢視 PDF，注意必須是檢視模式，不同模式取用路徑不同
            using frmPdfViewer frmPreview = new(letter, config, frmPdfViewer.OptMode.View);
            DialogResult result = frmPreview.ShowDialog();
            /// 手動 dispose，上述 using 寫法，不一定馬上釋放資源
            /// 如果沒有釋放，可能會影響後續操作，例如檔案無法刪除
            frmPreview.Dispose();

            if (result == DialogResult.Yes) //使用 DialogResult.Yes 表示需要處理
            {
                if (letter.LetterType == Model.LetterType.DUN || letter.LetterType == Model.LetterType.DPS) // 催款函
                {
                    // 傳入列印檔案，設定模式為補印 (抓取路徑不同)
                    new frmPrint(
                        config,
                        new List<Letter>() { letter },
                        frmPrint.Mode.Reprint
                        )
                        .ShowDialog();
                }
                else if (letter.LetterType == Model.LetterType.NTF)
                {
                    using FileService svc = new FileService(CurrentUser);
                    string downloadPath = svc.CopyFileToDownload(letter.ReviewTempPath);
                    MessageBox.Show($"檔案已經下載，將為您自動開啟路徑：{Environment.NewLine}{downloadPath}", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("explorer.exe", downloadPath);
                }
            }

            if (isAutoDelete)
                File.Delete(letter.ReviewTempPath);
        }

        private async void dgvDocLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // 替換為實際的按鈕欄位索引
            {
                // 取得備份路徑
                DataGridViewRow row = dgvDocLog.Rows[e.RowIndex];
                string remoteFullPath = row.Cells["BackupPath"]?.Value?.ToString() ?? "";

                if ("".Equals(remoteFullPath) || !File.Exists(remoteFullPath))
                {
                    MessageBox.Show("檔案不存在或無法取得");
                    return;
                }

                // 設定暫存路徑
                string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
                string tempFullPath = string.Empty;
                using (loader?.Start())
                {
                    await Task.Run(() =>
                    {
                        // 建立檔案服務，下載檔案到暫存資料夾
                        using FileService svcF = new FileService(CurrentUser, config?.Impersonator);
                        tempFullPath = svcF.SetRemoteFullPath(remoteFullPath)
                            .SetTempPath(tempPath)
                            .Download()
                            .TempFullPath;
                    });
                }

                string ltyp = row.Cells["LetterType"]?.Value?.ToString()!;
                string ftyp = row.Cells["FileType"]?.Value?.ToString()!;
                Letter letter = new(
                    (LetterType)Enum.Parse(typeof(LetterType), ltyp),
                    (FileType)Enum.Parse(typeof(FileType), ftyp),
                    tempFullPath
                    );

                // 顯示 PDF
                ViewPdf(letter);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetDocLog();
        }
    }
}
