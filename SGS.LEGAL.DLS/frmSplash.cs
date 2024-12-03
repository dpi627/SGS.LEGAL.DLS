//using Aspose.Pdf.Forms;
using Serilog;
using SGS.LEGAL.DLS.Model;
using SGS.LEGAL.DLS.Service;
using System.Diagnostics;

namespace SGS.LEGAL.DLS
{
    public partial class frmSplash : Form
    {
        bool _isInit = false; // 是否為程式初始化，是的話會執行初始化動作並顯示進度
        int _delay = 300; // delay time between each step task
        FormConfig? _config = null;

        public frmSplash(bool isInit = true, FormConfig? config = null)
        {
            InitializeComponent();
            this._isInit = isInit;
            this._config = config;
            labMsg.Text = "";
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            // set splash-form size equals to background image size
            Width = BackgroundImage.Width;
            Height = BackgroundImage.Height;
            // init circular progress bar
            InitProgressBar();
        }

        private async void frmSplash_Shown(object sender, EventArgs e)
        {
            if (_isInit)
            {
                UseWaitCursor = true;
                // 設定 timer 並啟用，開始更新進度
                timer1.Interval = 300; // timer 觸發間隔，單位 ms
                timer1.Tick += (sender, e) => TimerTick(sender, e);
                timer1.Enabled = true;

                try
                {
                    // 建立各種表單初始化設定，並回報內容與進度
                    FormConfig config = await SetFormConfigAsync();
                    Log.Information("完成設 {@config}", config);

                    // 直接設定為完成
                    AddProgress(100);
                    // 暫停讓 UI 得以更新 (不然會顯示 90 幾就跳掉)
                    await Task.Delay(1000);
                    // 顯示主畫面
                    ShowMainForm(config);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統異常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                finally
                {
                    timer1.Enabled = false;
                    UseWaitCursor = false;
                }
            }
            else
                btnClose.Visible = !_isInit;

            panel1.Visible = panel2.Visible = !_isInit;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            AddProgress();
        }

        /// <summary>
        /// 顯示主畫面
        /// </summary>
        /// <param name="config">系統設定</param>
        private void ShowMainForm(FormConfig config)
        {
            // 隱藏歡迎畫面
            this.Hide();
            // 建立主畫面
            frmMain main = new frmMain(config);
            // 設定主畫面關閉時，關閉歡迎畫面 (避免殘留資料)
            main.FormClosed += (sender, e) => this.Close();
            // 顯示主畫面
            main.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = "mailto:brian.li@sgs.com";
            Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 設定表單設定檔，同時更新訊息與進度
        /// </summary>
        /// <returns>系統表單設定檔</returns>
        private async Task<FormConfig> SetFormConfigAsync()
        {
            try
            {
                FormConfig config = await Task.Run(() =>
                {
                    ShowMsg("建立設定檔", 10);
                    return new FormConfig();
                });
                await Task.Delay(_delay);
                await Task.Run(() => { ShowMsg("設定目前使用者", 20); config.SetCurrentUser(); });
                await Task.Delay(_delay);
                await Task.Run(() => { ShowMsg("設定系統參數", 30); config.SetSystemData(); });
                await Task.Delay(_delay);
                await Task.Run(() => { ShowMsg("設定特殊IO帳號", 70); config.SetImpersonator(); });
                await Task.Delay(_delay);
                await Task.Run(() => { ShowMsg("設定通用資料", 80); config.SetCommonData(); });
                await Task.Delay(_delay);
                await Task.Run(() => { ShowMsg("設定印表機", 90); config.SetPrinter(); });
                await Task.Delay(_delay);

                return config;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "設定異常");
                throw;
            }
        }

        /// <summary>
        /// 顯示執行訊息同時更新進度
        /// </summary>
        /// <param name="msg">訊息內容</param>
        /// <param name="progressValue">進度</param>
        private void ShowMsg(string msg, int? progressValue = null)
        {
            this.Invoke((Action)(() =>
            {
                labMsg.Text = $"{msg}...";
                if (progressValue.HasValue)
                    AddProgress(progressValue.Value);
            }));
        }

        /// <summary>
        /// 進度條初始化
        /// </summary>
        private void InitProgressBar()
        {
            circularProgressBar1.Step = 1; // 每次加多少
            circularProgressBar1.Value = 0; // 起始值
            circularProgressBar1.StartAngle = 270; // 起始角度
            circularProgressBar1.ForeColor = Color.White;
            circularProgressBar1.ProgressColor = Color.Tomato;
        }

        /// <summary>
        /// 更新進度條
        /// </summary>
        /// <param name="value">進度值</param>
        private void AddProgress(int value = 0)
        {
            int currentValue = circularProgressBar1.Value;
            // 如果有給值就用，沒有就用隨機加上一個數值，感覺有在動
            int nextValue = value > 0 ? value : currentValue + circularProgressBar1.Step;
            // 更新進度，不能超過本身上限
            circularProgressBar1.Value = nextValue > circularProgressBar1.Maximum ? circularProgressBar1.Maximum : nextValue;
            // 更新中心顯示文字
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
        }

        private void lnkUserManual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_config == null)
                return;

            // 下載檔案到暫存資料夾
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
            using FileService svc = new FileService(_config.CurrentUser, _config.Impersonator);
            string tempFullPath = svc.SetRemoteFullPath(_config.UserManualFullPath!)
                .SetTempPath(tempPath)
                .Download()
                .TempFullPath;
            // 從暫存資料夾複製到下載
            string downloadPath = svc.CopyFileToDownload(tempFullPath);

            ProcessStartInfo psi = new()
            {
                FileName = downloadPath,
                UseShellExecute = true
            };
            Process.Start(psi);

            this.Close();
        }
    }
}
