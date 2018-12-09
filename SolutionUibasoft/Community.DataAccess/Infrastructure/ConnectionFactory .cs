using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Helpers;

namespace Community.DataAccess.Infrastructure
{

    public class ConnectionFactory : IConnectionFactory, IDisposable
    {
        private string _connectionString;
        private string _provider;

        public ConnectionFactory()
        {
            _provider = new SettingsHelper("Provider").GetSettingsConnection();
            _connectionString = new SettingsHelper("ConnectionString").GetSettingsConnection();
            
        }
        public IDbConnection GetConnection
        {
            get
            {
                var providerFactory = "System.Data.SqlClient";
                switch (_provider)
                {
                    case "SQLServer":
                        providerFactory = "System.Data.SqlClient";
                        break;
                    // Npgsql
                    //case "PostgreSQL":
                    //    _connection = new SqlConnection(_connectionString);
                    //    break;

                }
                var factory = DbProviderFactories.GetFactory(providerFactory);
                var connection = factory.CreateConnection();
                if (connection == null) throw  new ArgumentNullException(nameof(connection));                
                connection.ConnectionString = _connectionString;                
                return connection;

            }
        }

        public void Dispose()
        {
            GetConnection?.Dispose();
        }
    }
}
