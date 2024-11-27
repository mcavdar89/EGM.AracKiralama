using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAL.Abstracts
{
    public interface IBaseRepository
    {
        #region Insert, Update, Delete, SaveChanges, Rollback, Clear
        void Add<TEntity>(TEntity entity) where TEntity : Entity;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : Entity;
        void AddRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : Entity;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : Entity;

        void Update<TEntity>(TEntity entity) where TEntity : Entity;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : Entity;
        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : Entity;

        void AddOrUpdate<TEntity>(TEntity entity) where TEntity : Entity;
        Task AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : Entity;


        void Delete<TEntity>(TEntity entity, bool isSoftDelete = false) where TEntity : Entity;
        void DeleteRange<TEntity>(IEnumerable<TEntity> entityList, bool isSoftDelete = false) where TEntity : Entity;


        int SaveChanges();
        Task<int> SaveChangesAsync();

        void Rollback();
        void Clear();

        #endregion

        Task<List<T>>? ListAsync<T>(
         Expression<Func<T, bool>>? filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
         Func<IQueryable<T>, IQueryable<T>>? includes = null
         ) where T : Entity;

        Task<List<TModel>?>? ListProjectAsync<TEntity, TModel>(
          Expression<Func<TEntity, bool>>? filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
          Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null
          ) where TEntity : Entity;

        Task<TModel>? GetProjectAsync<TEntity, TModel>(
       Expression<Func<TEntity, bool>>? filter = null
       ) where TEntity : Entity;

        Task<TEntity>? GetAsync<TEntity>(
      Expression<Func<TEntity, bool>>? filter = null
      ) where TEntity : Entity;
        Task<TEntity>? GetFromSqlAsync<TEntity>(string sqlQuery) where TEntity : Entity;
        Task<List<TEntity>>? ListFromSqlAsync<TEntity>(string sqlQuery) where TEntity : Entity;
    }
}
