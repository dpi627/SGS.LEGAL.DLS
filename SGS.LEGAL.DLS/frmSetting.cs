namespace SGS.LEGAL.DLS
{
    public partial class frmSetting : frmBase
    {
        public bool IsModify = false;

        public frmSetting()
        {
            InitializeComponent();

            txtBossPathCCS.Text = settings.BOSS_PATH_CCS;
            txtBossPathFET.Text = settings.BOSS_PATH_FET;
            txtBossPathSGS.Text = settings.BOSS_PATH_SGS;
            txtBossPathTIS.Text = settings.BOSS_PATH_TIS;
            txtFileFormat.Text = settings.FILE_FORMAT;
        }

        /// <summary>
        /// 設定資料異動 = true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsHasBeenModified(object? sender, EventArgs e)
        {
            IsModify = true;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            // 綁定資料異動事件
            txtBossPathSGS.TextChanged += SettingsHasBeenModified;
            txtBossPathTIS.TextChanged += SettingsHasBeenModified;
            txtBossPathFET.TextChanged += SettingsHasBeenModified;
            txtBossPathCCS.TextChanged += SettingsHasBeenModified;
            txtFileFormat.TextChanged += SettingsHasBeenModified;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                // 儲存設定
                settings.BOSS_PATH_CCS = txtBossPathCCS.Text;
                settings.BOSS_PATH_FET = txtBossPathFET.Text;
                settings.BOSS_PATH_SGS = txtBossPathSGS.Text;
                settings.BOSS_PATH_TIS = txtBossPathTIS.Text;
                settings.FILE_FORMAT = txtFileFormat.Text;
                settings.Save();
                // reset modify flag
                IsModify = false;
                MessageBox.Show("儲存成功", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("儲存失敗", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBossPathSGS_Click(object sender, EventArgs e)
        {
            txtBossPathSGS.Text = Utility.GetFolderPath($"選擇{settings.SGS}資料來源");
        }

        private void btnBossPathTIS_Click(object sender, EventArgs e)
        {
            txtBossPathTIS.Text = Utility.GetFolderPath($"選擇{settings.TIS}資料來源");
        }

        private void btnBossPathFET_Click(object sender, EventArgs e)
        {
            txtBossPathFET.Text = Utility.GetFolderPath($"選擇{settings.FET}資料來源");
        }

        private void btnBossPathCCS_Click(object sender, EventArgs e)
        {
            txtBossPathCCS.Text = Utility.GetFolderPath($"選擇{settings.CCS}資料來源");
        }
    }
}
