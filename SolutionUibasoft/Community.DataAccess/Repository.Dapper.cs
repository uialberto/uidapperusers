using Community.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using  Dapper;

namespace Community.DataAccess
{
    public class RepositoryDapper<T> : IRepository<T>  where T : class
    {
        public IEnumerable<T> GetAll(string query)
        {
            using (var db = new FactoryDataAccess().GetConnection)
            {
                return db.Query<T>(query).ToList();
            }            
        }

        public int SaveData(string query, T data)
        {
            using (var db = new FactoryDataAccess().GetConnection)
            {
                return db.Execute(query, data);
            }
        }
    }
}
