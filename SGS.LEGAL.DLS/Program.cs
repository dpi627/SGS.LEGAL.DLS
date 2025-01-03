using Serilog;
using SGS.LEGAL.DLS.Service;
using SGS.LIB.Common;
using SGS.OAD.Helper;
using System.Diagnostics;
using System.Reflection;

namespace SGS.LEGAL.DLS
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "SGS.LEGAL.DLS";
            Debug.WriteLine(VersionHelper.CurrentVersion);
            #region 設定 Serilog 日誌記錄器
            using (ConfigReader? cr = new())
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(cr.Config)
                    .Enrich.WithProperty("Application", appName)
                    .Enrich.WithProperty("Version", VersionHelper.CurrentVersion)
                    .CreateLogger();
            }
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(new ConfigReader().Config)
            //    .CreateLogger();
            #endregion

            #region 在 Serilog 執行異常時中斷，設定僅為 DEBUG 啟用
#if DEBUG
            //Serilog.Debugging.SelfLog.Enable(msg =>
            //{
            //    Debug.Print(msg);
            //    Log.Error(msg);
            //    Debugger.Break();
            //});
#endif
            #endregion

#if RELEASE
            #region 系統允許執行時間判斷
            // 取得參數表允許執行時間，嘗試轉為整數，如失敗設定為預設值
            using SysParamService svc = new(null);
            int.TryParse(svc.Get("TIME_START")!.FirstOrDefault()!.P_VAL, out int startHour);
            int.TryParse(svc.Get("TIME_END")!.FirstOrDefault()!.P_VAL, out int endHour);
            if (startHour ==0 || endHour == 0)
            {
                startHour = 10;
                endHour = 21;
            }
            // 取得當前時間進行比較
            int currentHour = DateTime.Now.Hour;
            if (currentHour < startHour || currentHour > endHour)
            {
                MessageBox.Show($"資料處理中...{Environment.NewLine}{Environment.NewLine}請於每日 {startHour} 時至 {endHour} 時之間執行");
                return;
            }
            #endregion
#endif

            Log.Information("{Application} {Version} Start");

            ApplicationConfiguration.Initialize();
            Application.Run(new frmSplash());

            // 清理和關閉 Serilog 日誌記錄器
            Log.CloseAndFlush();
        }
    }
}