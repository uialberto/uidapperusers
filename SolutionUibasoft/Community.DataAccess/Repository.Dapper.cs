using Community.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public class RepositoryDapper<T> : IRepository<T>  where T : class
    {
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(string query)
        {
            using (var db = new FactoryDataAccess().GetConnection)
            {
                return db.Query<T>(query).ToList();
            }            
        }

        public Task<IEnumerable<T>> GetAllAsync(string query)
        {
            throw new NotImplementedException();
        }

        public int SaveData(string query, T data)
        {
            using (var db = new FactoryDataAccess().GetConnection)
            {
                return db.Execute(query, data);
            }
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
