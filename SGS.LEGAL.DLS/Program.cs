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
            #region �]�w Serilog ��x�O����
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

            #region �b Serilog ���沧�`�ɤ��_�A�]�w�Ȭ� DEBUG �ҥ�
#if DEBUG
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Log.Error(msg);
                Debugger.Break();
            });
#endif
            #endregion

            #region �إߪ��]�w
            FormConfig config = new FormConfig()
                .SetCurrentUser()   // �]�w�ثe�ϥΪ�
                .SetImpersonator()  // �]�w�S��AD�b��
                .SetCommonData()    // �]�w�q�θ��
                .SetPrinter();      // �]�w�L���
            #endregion

            Log.Debug("App Start");

            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain(config));

            Log.Debug("App End");

            // �M�z�M���� Serilog ��x�O����
            Log.CloseAndFlush();
        }
    }
}