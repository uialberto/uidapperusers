using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string query);
        int SaveData(string query, T data);
    }
}
