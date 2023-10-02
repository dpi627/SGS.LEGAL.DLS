using Serilog;
using SGS.LEGAL.DLS.Model;
using SGS.LIB.Common;
using System.Diagnostics;

namespace SGS.LEGAL.DLS
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            #region 設定 Serilog 日誌記錄器
            using (ConfigReader? cr = new())
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(cr.Config)
                    .CreateLogger();
            }
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(new ConfigReader().Config)
            //    .CreateLogger();
            #endregion

            #region 在 Serilog 執行異常時中斷，設定僅為 DEBUG 啟用
#if DEBUG
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Log.Error(msg);
                Debugger.Break();
            });
#endif
            #endregion

            #region 建立表單設定
            FormConfig config = new FormConfig()
                .SetCurrentUser()   // 設定目前使用者
                .SetImpersonator()  // 設定特殊AD帳號
                .SetCommonData()    // 設定通用資料
                .SetPrinter();      // 設定印表機
            #endregion

            Log.Debug("App Start");

            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain(config));

            Log.Debug("App End");

            // 清理和關閉 Serilog 日誌記錄器
            Log.CloseAndFlush();
        }
    }
}