
using AutoMapper;
using Infra.DAL.Abstracts;
using Infra.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAL.Concretes
{
    public class BaseRepository:IBaseRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;
        public BaseRepository(DbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        #region Insert, Update, Delete, SaveChanges, Rollback, Clear
        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Add(entity);
        }
        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            await _context.AddAsync(entity);
        }
        public void AddRange<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity
        {
            _context.AddRange(entityList);
        }
        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity
        {
            await _context.AddRangeAsync(entityList);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
                return;
            var keys = entity.GetPrimaryKeyValues().ToArray();
            var existing = _context.Set<TEntity>().Find(keys);
            if (existing == null)
                return;

            //TEntity existing = _context.Set<TEntity>().Find(entity.GetPrimaryKeyValues());
            //entity.GetType().GetProperties().FirstOrDefault(d => d.Name == "Id").GetValue(entity));

            _context.Entry(existing).CurrentValues.SetValues(entity);


        }
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
                return;

            var keys = entity.GetPrimaryKeyValues().ToArray();

            var existing = await _context.Set<TEntity>().FindAsync(keys);
            if (existing == null)
                return;

            await Task.Run(() => _context.Entry(existing).CurrentValues.SetValues(entity));

        }
        public void UpdateRange<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity
        {
            _context.UpdateRange(entityList);
        }
        public async Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity
        {
            await Task.Run(() => _context.UpdateRange(entityList));
        }

        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : Entity
        {

            var keys = entity.GetPrimaryKeyValues();
            var any = _context.Set<TEntity>().Find(keys);
            if (any == null)
            {
                _context.Set<TEntity>().Add(entity);
            }
            else
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Entry(any).CurrentValues.SetValues(entity);
                    _context.Entry(any).State = EntityState.Modified;

                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

            }

        }
        public async Task AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {

            if (entity.LastTransactionDate == DateTime.MinValue)
            {
                entity.LastTransactionDate = DateTime.Now;
            }

            var keys = entity.GetPrimaryKeyValues();
            var any = await _context.Set<TEntity>().FindAsync(keys);
            if (any == null)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            else
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Entry(any).CurrentValues.SetValues(entity);
                    _context.Entry(any).State = EntityState.Modified;

                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

            }
        }


        public void Delete<TEntity>(TEntity entity, bool isSoftDelete = false) where TEntity : Entity
        {
            if (!isSoftDelete)
            {
                entity.StatusId = 0;
                Update(entity);
            }
            else _context.Set<TEntity>().Remove(entity);
        }
        public async Task DeleteAsync<TEntity>(TEntity entity, bool isSoftDelete = false) where TEntity : Entity
        {
            if (!isSoftDelete)
            {
                entity.StatusId = 0;
                await UpdateAsync(entity);
            }
            else await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entityList, bool isSoftDelete = false) where TEntity : Entity
        {
            if (!isSoftDelete)
            {
                foreach (var entity in entityList)
                {
                    entity.StatusId = 0;
                    Update(entity);
                }
            }
            else _context.Set<TEntity>().RemoveRange(entityList);
        }
        public async Task DeleteRangeAsync<TEntity>(IEnumerable<TEntity> entityList, bool isSoftDelete = false) where TEntity : Entity
        {
            if (!isSoftDelete)
            {
                foreach (var entity in entityList)
                {
                    entity.StatusId = 0;
                    await UpdateAsync(entity);
                }
            }
            else await Task.Run(() => _context.Set<TEntity>().RemoveRange(entityList));
        }





        public int SaveChanges()
        {

            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex ?? new Exception("SaveChanges işleminde beklenmeye bir hata ile kaşılaşıldı.");
            }
            finally
            {
                Clear();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync(default);
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex ?? new Exception("SaveChanges işleminde beklenmeye bir hata ile kaşılaşıldı.");
            }
            finally
            {
                Clear();
            }
        }

        public void Rollback()
        {
            (_context as DbContext).ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
        public void Clear()
        {
            (_context as DbContext).ChangeTracker.Clear();
        }



        #endregion

        public virtual async Task<List<T>>? ListAsync<T>(
         Expression<Func<T, bool>>? filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
         Func<IQueryable<T>, IQueryable<T>>? includes = null
         ) where T : Entity
        {

            IQueryable<T> dbSet = _context.Set<T>();
            if (filter != null)
            {
                dbSet = dbSet.Where(filter);
            }
            if (includes != null)
            {
                dbSet = includes(dbSet);
            }
            if (orderBy != null)
            {
                dbSet = orderBy(dbSet);
            }
            return await dbSet.ToListAsync();


        }


        public async Task<List<TModel>?>? ListProjectAsync<TEntity, TModel>(
          Expression<Func<TEntity, bool>>? filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
          Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null
          ) where TEntity : Entity
        {
            IQueryable<TEntity> dbSet = _context.Set<TEntity>();
            if (filter != null)
            {
                dbSet = dbSet.Where(filter);
            }
            if (includes != null)
            {
                dbSet = includes(dbSet);
            }
            if (orderBy != null)
            {
                dbSet = orderBy(dbSet);
            }

           var result = _mapper.ProjectTo<TModel>(dbSet);


            if (result == null)
                return null;

            return await result.ToListAsync();
        }


    }
}
