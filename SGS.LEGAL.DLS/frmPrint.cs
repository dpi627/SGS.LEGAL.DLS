using Aspose.Pdf.Forms;
using PdfiumViewer;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Model;
using System.Data;
using System.Drawing.Printing;
using p = SGS.LIB.Common.PrinterHelper;

namespace SGS.LEGAL.DLS
{
    public partial class frmPrint : System.Windows.Forms.Form
    {
        public enum Mode
        {
            Print,
            Reprint
        }

        /// 取得本機印表機清單，轉為字串陣列
        /// 排除無效項目 (無紙匣、傳真等等)
        readonly string[] LocalPrinters;
        List<PaperSource> PaperSources;
        readonly List<Letter> _letters;
        readonly Mode _mode;
        private readonly FormConfig? config;
        private SYS_USER? CurrentUser => config?.CurrentUser;

        public frmPrint(FormConfig config, List<Letter> letters, Mode mode = Mode.Print)
        {
            InitializeComponent();
            this._letters = letters;
            this._mode = mode;
            this.labMsg.Text = "";
            this.config = config;
            this.LocalPrinters = config.DefaultPrinters;
            this.PaperSources = config.DefaultPaperSources;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            // 設定預設印表機清單
            SetPrinters(ref cbbLetterPrinter, cbbLetterPrinter_SelectedIndexChanged);
            SetPrinters(ref cbbReceiptPrinter, cbbReceiptPrinter_SelectedIndexChanged);
            SetPrinters(ref cbbEnvelopePrinter, cbbEnvelopePrinter_SelectedIndexChanged);
            // 設定預設紙匣清單
            SetPaperSources(PaperSources, ref cbbLetterPaper);
            SetPaperSources(PaperSources, ref cbbReceiptPaper);
            SetPaperSources(PaperSources, ref cbbEnvelopePaper);
            // 設定列印區塊啟用
            SetGroupBox();
        }

        /// <summary>
        /// 檢查列印信函類型是否吻合印表機Tag
        /// 存在對應類型才啟用列印，例如有信封就啟用信封列印設定
        /// </summary>
        private void SetGroupBox()
        {
            this.Controls.OfType<GroupBox>().ToList()
                .ForEach(x => x.Enabled =
                    this._letters
                        .Where(y => y.FileType.ToString() == x.Tag.ToString())
                        .Count() > 0
                );
            //this._letters[0].FileType;
        }

        /// <summary>
        /// 設定印表機清單
        /// 1) 移除事件，避免操作時觸發
        /// 2) 清除原有項目，避免重複加入
        /// </summary>
        /// <param name="cbb">指定 combobox</param>
        /// <param name="eventName">要取消/綁定事件</param>
        private void SetPrinters(ref ComboBox cbb, EventHandler eventName)
        {
            //移除事件，避免操作時觸發
            cbb.SelectedIndexChanged -= eventName;
            //清除原有項目，避免重複加入
            cbb.Items.Clear();
            //沒有資料返回
            if (LocalPrinters.Length <= 0)
                return;
            //加入項目
            cbb.Items.AddRange(LocalPrinters);
            //預設選擇第一台印表機
            cbb.SelectedIndex = 0;
            //上面設定好才可以恢復事件綁定，避免直接觸發
            cbb.SelectedIndexChanged += eventName;
        }

        /// <summary>
        /// 設定紙匣下拉選單，選擇印表機後觸發
        /// </summary>
        /// <param name="printerName">印表機名稱</param>
        /// <param name="cbb">要設定的下拉選單</param>
        private static void SetPaperSources(string printerName, ref ComboBox cbb)
        {
            // 取得印表機紙匣 (觀看資料好像只有 RawKind < 1000 的才是紙匣)
            var paperSources = p.GetPaperSources(printerName);
            SetPaperSources(paperSources, ref cbb);
        }
        /// <summary>
        /// 設定紙匣下拉選單
        /// 初始化時設定，或(以印表機名稱)獲得紙匣後設定
        /// </summary>
        /// <param name="paperSources">紙匣集合</param>
        /// <param name="cbb">要設定的下拉選單</param>
        private static void SetPaperSources(List<PaperSource>? paperSources, ref ComboBox cbb)
        {
            //清除原有項目，避免重複加入
            cbb.Items.Clear();
            //如果沒資料就離開
            if (paperSources.Count <= 0)
                return;
            //指定資料與顯示欄位
            cbb.DisplayMember = "TXT";
            cbb.ValueMember = "VAL";
            //加入項目，使用自訂類別 ComboBoxItem
            foreach (PaperSource ps in paperSources)
                cbb.Items.Add(new ComboBoxItem(
                    ps.RawKind, //這個參數最為重要，可視為印表機紙匣ID
                    ps.RawKind.ToString(),
                    $"{ps.RawKind:0000} - {ps.SourceName}"
                    ));
            //預設選擇第一個
            cbb.SelectedIndex = 0;
        }

        /// <summary>
        /// 設定印表機列印文件 (PrintDocument)
        /// </summary>
        /// <param name="printers">印表機下拉選單</param>
        /// <param name="printerSources">印表機紙匣下拉選單</param>
        /// <param name="fileType">檔案類型，信函、信封、收件回執</param>
        private void PrintFile(ref ComboBox printers, ref ComboBox printerSources, FileType fileType)
        {
            // 取得路徑
            string? path = _letters?.FirstOrDefault(x => x.FileType == fileType)?.TempFullPath;

            // 如果是重印(補印)，預設路徑不同
            if (this._mode == Mode.Reprint)
                path = _letters?.FirstOrDefault(x => x.FileType == fileType)?.ReviewTempPath;

            if (string.IsNullOrWhiteSpace(path)) return;

            // 取得選擇印表機名稱
            string printerName = printers.Text;
            // 取得選擇紙匣項目
            ComboBoxItem selectedItem = (ComboBoxItem)printerSources.SelectedItem;
            // 依照選取項目建立紙匣類別 (RawKind一定要設定)
            PaperSource paperSource = new()
            {
                RawKind = selectedItem.IDX,     //必填
                SourceName = selectedItem.TXT   //可以不填
            };
            // 設定列印訊息
            //SetStatusMessage(Path.GetFileName(path) ?? "");
            this.Text = $"正在列印... {Path.GetFileName(path) ?? ""}";
            // 列印
            PrintPDF(path, printerName, paperSource);
        }

        /// <summary>
        /// 列印PDF，指定印表機與紙匣
        /// </summary>
        /// <param name="pdfPath">PDF路徑</param>
        /// <param name="printerName">印表機名稱</param>
        /// <param name="paperSource">紙匣類別</param>
        private void PrintPDF(string pdfPath, string printerName, PaperSource paperSource)
        {
            using (PdfDocument? pdf = PdfDocument.Load(pdfPath))
            {
                using (PrintDocument printDocument = pdf.CreatePrintDocument())
                {
                    // 設定名稱 (非必要)
                    printDocument.DocumentName = Path.GetFileName(pdfPath);
                    // 設定名稱 (非必要)
                    printDocument.PrinterSettings.PrintFileName = Path.GetFileName(pdfPath);
                    // 設定印表機名稱 (必要)
                    printDocument.PrinterSettings.PrinterName = printerName;
                    // 設定紙匣 (必要)
                    printDocument.DefaultPageSettings.PaperSource = paperSource;
                    // 使用彩色列印
                    printDocument.DefaultPageSettings.Color = true;
                    // 列印
                    printDocument.Print();
                }
            }

            Utility.AddLog(OptLogType.Print, CurrentUser!, this.GetType().Name, $"doc:{pdfPath} printer:{printerName} paperSource:{paperSource}");
        }

        /// <summary>
        /// 設定所有印表機文件
        /// </summary>
        private void SetAllPrintDocument()
        {
            PrintFile(ref cbbLetterPrinter, ref cbbLetterPaper, FileType.L);
            PrintFile(ref cbbReceiptPrinter, ref cbbReceiptPaper, FileType.R);
            PrintFile(ref cbbEnvelopePrinter, ref cbbEnvelopePaper, FileType.E);
        }

        private void cbbLetterPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPaperSources(cbbLetterPrinter.Text, ref cbbLetterPaper);
        }

        private void cbbReceiptPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPaperSources(cbbReceiptPrinter.Text, ref cbbReceiptPaper);
        }

        private void cbbEnvelopePrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPaperSources(cbbEnvelopePrinter.Text, ref cbbEnvelopePaper);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SetAllPrintDocument();
            DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
