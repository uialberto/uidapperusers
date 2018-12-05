using System;
using System.Data;
using System.Data.SqlClient;

namespace Community.DataAccess.Helpers
{
    public class FactoryDataAccess : IDisposable
    {
        public FactoryDataAccess()
        {
            var provider = new SettingsHelper("Provider").GetSettingsConnection();
            var connectionString = new SettingsHelper("ConnectionString").GetSettingsConnection();
            switch (provider)
            {
                case "SQLServer":
                    GetConnection = new SqlConnection(connectionString);
                    break;
                    // Npgsql
                    //case "PostgreSQL":
                    //    _connection = new SqlConnection(_connectionString);
                    //    break;

            }
        }

        public IDbConnection GetConnection { get; }

        public void Dispose()
        {
            GetConnection?.Dispose();
        }
    }
}
