using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Infrastructure;
using Dapper;

namespace Community.DataAccess
{
    public class RepositoryDapperGeneric<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll(string query)
        {
            using (var db = new ConnectionFactory().GetConnection)
            {
                return db.Query<TEntity>(query).ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            using (var db = new ConnectionFactory().GetConnection)
            {
                return await db.QueryAsync<TEntity>(query);
            }
        }

        public int SaveData(string query, TEntity data)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(object id)
        {
            throw new NotImplementedException();
        }

        public int Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
