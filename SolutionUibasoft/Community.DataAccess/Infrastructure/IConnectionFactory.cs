using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.DataAccess.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
