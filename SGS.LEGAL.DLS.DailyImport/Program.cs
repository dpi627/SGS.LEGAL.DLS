using Serilog;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;

namespace SGS.LEGAL.DLS.DailyImport
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 建立資料匯入服務
            using DataImportService di = new(
                new SYS_USER() { USER_ID = "SYSOP" },
                new DATA_IMPORT()
                );
            // 執行資料匯入
            di.ImportData();

            Log.CloseAndFlush();
        }
    }
}