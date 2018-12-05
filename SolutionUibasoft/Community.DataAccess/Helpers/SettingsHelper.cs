using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Community.DataAccess.Helpers
{
    public class SettingsHelper
    {

        private readonly string _connectionString;

        public SettingsHelper(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public string GetSettingsConnection()
        {
            var setting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var clave = setting.GetConnectionString(_connectionString);
            return clave;

        }

    }
}
