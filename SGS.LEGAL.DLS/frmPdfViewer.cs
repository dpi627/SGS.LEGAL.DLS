using PdfiumViewer;
using SGS.LEGAL.DLS.Model;

namespace SGS.LEGAL.DLS
{
    public partial class frmPdfViewer : Form
    {
        public enum OptMode
        {
            View,   // 檢視，例如查詢歷史資料，除了檢視無其他功能
            Review  // 審核，產生催款函過程中顯示，包含流程操作按鈕
        }

        private string _path;
        private readonly Letter letter;
        private readonly FormConfig config;
        OptMode mode;

        public frmPdfViewer(Letter letter, FormConfig config, OptMode mode = OptMode.Review)
        {
            this.letter = letter;
            this.config = config;
            this.mode = mode;
            Init();
        }

        private void Init()
        {
            // 原本 windows form 初始化
            InitializeComponent();
            // 視窗放最大
            WindowState = FormWindowState.Maximized;
            // 設定pdf路徑，產出流程預覽與檢視歷程紀錄路徑不同
            _path = mode == OptMode.Review ? letter.TempFullPath : letter.ReviewTempPath;
            /// 綁定 Dispose 方法，可以同時釋放資源
            /// 不過還是建議手動操作
            Disposed += (s, e) => pdfViewer1.Document?.Dispose();
            // 設定按鈕顯示
            btnApprove.Visible = mode == OptMode.Review;
            btnReprint.Visible = (mode == OptMode.View) && (letter.LetterType != LetterType.NTF);
            btnDownload.Visible = (mode == OptMode.View) && (letter.LetterType == LetterType.NTF);

            txtFileType.Text = config.FileTypes
                .Where(x => x.P_VAL == letter.FileType.ToString())
                .FirstOrDefault()
                .P_TXT;
            txtLetterType.Text = config.LetterTypes
                .Where(x => x.P_VAL == letter.LetterType.ToString())
                .FirstOrDefault().P_TXT;
        }

        private void frmPdfViewer_Load(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            pdfViewer1.Document?.Dispose();
            pdfViewer1.Document = OpenDocument(_path);
            pdfViewer1.ZoomMode = PdfViewerZoomMode.FitBest; //預設自動判斷顯示模式
        }

        private PdfDocument? OpenDocument(string fileName)
        {
            try
            {
                return PdfDocument.Load(this, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void FitPage(PdfViewerZoomMode zoomMode)
        {
            int page = pdfViewer1.Renderer.Page;
            pdfViewer1.ZoomMode = zoomMode;
            pdfViewer1.Renderer.Zoom = 1;
            pdfViewer1.Renderer.Page = page;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnFitWidth_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitWidth);
        }

        private void btnFitHeight_Click(object sender, EventArgs e)
        {
            FitPage(PdfViewerZoomMode.FitHeight);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pdfViewer1.Renderer.Zoom += 0.5;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pdfViewer1.Renderer.Zoom -= 0.5;
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            // 使用內建列舉表示需要後續處理
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // 使用內建列舉表示需要後續處理
            DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
