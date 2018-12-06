using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(string query);
        int SaveData(string query, TEntity data);
        TEntity Get(long id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
