using Microsoft.EntityFrameworkCore;
using Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RDBMS
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T>
       where T : class
    {
        protected ApplicationDbContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.AsQueryable<T>().ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbset.Where(expression).AsQueryable<T>().ToListAsync();
        }


        public async virtual Task<T> Details(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);

        }

        public async virtual Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AsNoTracking().FirstOrDefaultAsync(expression) != null;
        }

        public async virtual Task<T> Add(T entity)
        {
            await _dbset.AddAsync(entity);
            return entity;
        }

        public async virtual Task Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            await Task.CompletedTask;
        }

        private void AvoidPropertyToModify(T entity, List<object> avoidedProperties)
        {
            if (avoidedProperties != null)
            {
                foreach (var item in avoidedProperties)
                {
                    foreach (PropertyInfo p in item.GetType().GetProperties())
                        _entities.Entry(entity).Property(p.Name).IsModified = false;
                }
            }
        }

        public async virtual Task DeleteRange(Expression<Func<T, bool>> predicate)
        {
            var details = _dbset.Where(predicate).AsQueryable();
            if (details.Count() > 0)
            {
                _entities.Set<T>().RemoveRange(details);
            }

            await Task.CompletedTask;
        }

        public async virtual Task Edit(T entity, List<object> avoidedProperties)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            AvoidPropertyToModify(entity, avoidedProperties);

            await Task.CompletedTask;
        }


        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> SaveChanges()
        {
            // Save changes with the default options
            return await _entities.SaveChangesAsync();
        }

        private bool disposed = false;
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
                this.disposed = true;
            }
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T DetailSync(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public void EditSync(T entity, List<object> avoidedProperties)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            AvoidPropertyToModify(entity, avoidedProperties);
        }

        public void SaveChangesSync()
        {
            _entities.SaveChanges();
        }
    }

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Details(Expression<Func<T, bool>> predicate);
        Task<bool> IsExist(Expression<Func<T, bool>> expression);
        Task DeleteRange(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Edit(T entity, List<object> avoidedProperties);
        Task<int> SaveChanges();
        void Dispose();
        T DetailSync(Expression<Func<T, bool>> predicate);
        void EditSync(T entity, List<object> avoidedProperties);
        void SaveChangesSync();

    }
}
