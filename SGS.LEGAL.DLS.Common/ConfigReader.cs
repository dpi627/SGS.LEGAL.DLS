using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGS.LIB.Common
{
    public class ConfigReader : IDisposable
    {
        private bool _disposed = false;
        private readonly IConfiguration _config;
        public IConfiguration Config => _config;

        public ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();
        }

        public string? GetConnStr(string connectionName) => _config.GetConnectionString(connectionName);

        public string? GetValue(string key)
        {
            return _config[key];
        }

        public Dictionary<string, string?> GetSection(string key, string settingName = "")
        {
            if (!string.IsNullOrEmpty(settingName))
                key = $"{settingName}:{key}";

            return _config
                .GetSection(key)
                .GetChildren()
                .ToDictionary(x => x.Key, x => x.Value);
        }

        #region dispose synax
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ConfigReader()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //SetProfilerLog();
                }
                _disposed = true;
            }
        }
        #endregion
    }
}
