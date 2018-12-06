using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public class RepositoryDapperGeneric<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public int SaveData(string query, TEntity data)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
