using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Community.DataAccess.Helpers
{
    public class SettingsHelper
    {

        private readonly string _connectionString;

        public SettingsHelper( string connectionString)
        {
                if(connectionString ==null) throw new ArgumentNullException(nameof(connectionString));
        }

        public string GetSettingsConnection()
        {
            var setting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            return setting.GetConnectionString(_connectionString);

        }

    }
}
