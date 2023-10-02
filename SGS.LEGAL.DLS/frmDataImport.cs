using LoadingIndicator.WinForms;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Service;

namespace SGS.LEGAL.DLS
{
    public partial class frmDataImport : Form
    {
        private readonly FormConfig? config;
        private readonly LongOperation? loader;

        private SYS_USER? CurrentUser => config?.CurrentUser;

        public frmDataImport() { }
        public frmDataImport(FormConfig config)
        {
            InitializeComponent();

            this.config = config;
            this.loader = new LongOperation(this);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewCellStyle cellStyle = new();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle = cellStyle;

            dataGridView1.Columns["FinishReason"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void frmDataImport_Load(object sender, EventArgs e)
        {
            Utility.SetComboBox(ref cbbCompany, "COMPANY", true, "所有公司");
            GetImportData();
        }

        /// <summary>
        /// 取得最新匯入紀錄
        /// </summary>
        private void GetImportData()
        {
            using DataImportService svc = new(CurrentUser, new DATA_IMPORT());
            dataGridView1.DataSource = svc.Get();
        }

        private async void btnDataImport_Click(object sender, EventArgs e)
        {
            var comID = cbbCompany.SelectedValue.ToString();

            if (comID is "" or "SGS")
            {
                DialogResult result = MessageBox.Show(
                    $"選擇項目資料量過多，執行期間請勿關閉視窗{Environment.NewLine}{Environment.NewLine}確認執行?",
                    "系統訊息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                if (result == DialogResult.No) return;
            }
            await DataImportManualAsync(comID);
            GetImportData();
        }

        /// <summary>
        /// (非同步)手動資料匯入
        /// </summary>
        /// <param name="CompanyID">公司ID</param>
        /// <returns></returns>
        private async Task DataImportManualAsync(string? CompanyID)
        {
            using (loader.Start())
            {
                await Task.Run(() =>
                {
                    try
                    {
                        using var svc = new DataImportService(CurrentUser, new DATA_IMPORT());
                        svc.ImportData(true, CompanyID);
                        MessageBox.Show("手動匯入完成", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            GetImportData();
        }
    }
}
