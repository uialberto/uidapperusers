﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(string query);
        Task<IEnumerable<TEntity>> GetAllAsync(string query);
        int SaveData(string query, TEntity data);
        TEntity Get(object id);
        int Add(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity entity);

    }
}
