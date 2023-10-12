using AutoUpdaterDotNET;
using System.Diagnostics;
using Serilog;
using SGS.LEGAL.DLS.Model;

namespace SGS.LEGAL.DLS
{
    public partial class frmMain : Form
    {
        // 表單設定
        private FormConfig _config;
        // 子標單類別與實體暫存
        private Dictionary<Type, Form> _subForms = new();

        public frmMain(FormConfig config)
        {
            InitializeComponent();
            this._config = config;
            Log.Information($"{_config.CurrentUser?.EMP_ID} Login");
            Utility.AddLog(OptLogType.Login, _config.CurrentUser!, this.GetType().Name);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            #region Debug / Release 模式下的設定
#if RELEASE
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.Start(@"\\twfs007\SGSSHARE\OAD\Brian\_Auto_Update\SGS.LEGAL.DLS\info.xml");
            btnDemo.Visible = false;
#endif
#if DEBUG
            //btnNotify_Click(sender, e);
            btnHistory_Click(sender, e);
#endif
            #endregion

            // 設定使用者名稱
            labUser.Text = (_config.CurrentUser != null) ? _config.CurrentUser.USER_DISP : "Unknow";
            // 設定版本
            labVersion.Text = FileVersionInfo.GetVersionInfo(Environment.ProcessPath).FileVersion;
        }

        #region 載入 隱藏 顯示子表單
        /// <summary>
        /// 載入子表單
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="formTitle">標單標題</param>
        private void LoadForm<T>(string formTitle) where T : Form, new()
        {
            labTitle.Text = formTitle;

            if (panContent.Controls.Count > 0)
                HideSubForms();

            // 子表單如已存在，直接顯示
            Type subFormType = typeof(T);
            if (_subForms.ContainsKey(subFormType))
            {
                T subForm = (T)_subForms[subFormType];
                subForm.Show();
                return;
            }

            AddSubForm<T>();
        }

        /// <summary>
        /// 加入子表單
        /// </summary>
        private void AddSubForm<T>() where T : Form, new()
        {
            // 建立表單實體，並將 config 參數傳遞給建構函式
            T subForm = Activator.CreateInstance(typeof(T), new object[] { _config }) as T ?? new();
            subForm.TopLevel = false;
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;

            // 加入表單
            panContent.Controls.Add(subForm);
            subForm.Show();

            // 加入暫存陣列
            _subForms.Add(typeof(T), subForm);
        }

        /// <summary>
        /// 隱藏所有子表單
        /// </summary>
        private void HideSubForms()
        {
            // 隱藏所有子表單
            foreach (System.Windows.Forms.Control control in panContent.Controls)
            {
                control.Hide();
            }
        }
        #endregion

        private void btnDataImport_Click(object sender, EventArgs e)
        {
            LoadForm<frmDataImport>("資料匯入");
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            LoadForm<frmDunningLetter>("催款函");
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            LoadForm<frmDemo>("demo");
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            LoadForm<frmUser>("使用者資訊");
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadForm<frmDocLog>("歷程紀錄");
        }
    }
}
