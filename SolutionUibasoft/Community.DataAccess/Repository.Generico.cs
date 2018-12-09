using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public class RepositoryGenerico<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;

        public RepositoryGenerico(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection), $"El parametro {nameof(connection)} no puede ser null");
        }
        public int Add(TEntity entity)
        {
            var query = string.Empty;
            // ToDo Query Generator...
            var result = _connection.Execute(query, entity);
            return result;
        }

        public int Delete(TEntity entity)
        {
            var query = string.Empty;
            // ToDo Query Generator...
            var result = _connection.Execute(query, entity);
            return result;
        }

        public TEntity Get(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id), $"El parametro {nameof(id)} no puede ser null");
            var query = string.Empty;
            // ToDo Query Generator...
            var result = _connection.Query<TEntity>(query, id).FirstOrDefault();
            return result;
        }

        public IEnumerable<TEntity> GetAll(string query)
        {
            var result = _connection.Query<TEntity>(query);
            return result;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            return Task.Run(() => GetAll(query));
        }

        public int SaveData(string query, TEntity data)
        {
            var result = _connection.Execute(query, data);
            return result;
        }

        public int Update(TEntity entity)
        {
            var query = string.Empty;
            // ToDo Query Generator...
            var result = _connection.Execute(query, entity);
            return result;
        }
    }
}
