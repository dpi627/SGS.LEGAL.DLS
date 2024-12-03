using Serilog;
using SGS.LEGAL.DLS.Entity;
using System.Reflection;

namespace SGS.LEGAL.DLS.Service
{
    public class BaseService : IDisposable
    {
        private bool disposed = false;
        protected SYS_USER? logiinUser;

        protected static ILogger Logger { get; }

        static BaseService()
        {
            Serilog.Debugging.SelfLog.Enable(msg => Console.Error.WriteLine(msg));
            var appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "SGS.LEGAL.DLS";

            Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(
                    path: @"C:\SGSLIMS\Log\SGS.LEGAL.DLS.DailyImport\.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .WriteTo.Seq("http://twtpeoad002:5341/")
                .Enrich.WithEnvironmentName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithProperty("Application", appName)
                .CreateLogger();

            try
            {
                #region Load ASPOSE license
                new Aspose.Pdf.License().SetLicense("Aspose.Total.655.lic");
                new Aspose.Cells.License().SetLicense("Aspose.Total.655.lic");
                new Aspose.Words.License().SetLicense("Aspose.Total.655.lic");
                #endregion
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Load ASPOSE license failed.");
                throw;
            }
        }

        public BaseService(SYS_USER? user)
        {
            logiinUser = user ?? new SYS_USER();
        }

        #region dispose synax
        public void Dispose()
        {
            Log.CloseAndFlush();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //SetProfilerLog();
                }
                disposed = true;
            }
        }
        #endregion
    }
}
