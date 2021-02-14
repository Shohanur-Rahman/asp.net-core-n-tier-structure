using Repository.RDBMS;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericServices
{
    public class OperationServices<T> : IOperationServices<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public OperationServices(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async virtual Task<bool> IsExist(Expression<Func<T, bool>> expression)
        {
            return await _repository.IsExist(expression);
        }

        public async virtual Task<int> SaveChanges()
        {
            return await _repository.SaveChanges();
        }

        public async virtual Task<T> Save(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _repository.Add(entity);
            return entity;
        }


        public async virtual Task<bool> Update(T entity, List<object> avoidedProperties)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            await _repository.Edit(entity, avoidedProperties);
            return true;

        }

        public async virtual Task<bool> Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            await _repository.Delete(entity);
            return true;
        }

        public async virtual Task<bool> DeleteRange(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("entity");
            await _repository.DeleteRange(predicate);
            return true;
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async virtual Task<T> Details(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException("entity");
            return await _repository.Details(predicate);
        }

        public async virtual Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            if (expression == null) throw new ArgumentNullException("entity");
            return await _repository.GetAll(expression);
        }

        public T DetailSync(Expression<Func<T, bool>> predicate)
        {
            return _repository.DetailSync(predicate);
        }

        public bool UpdateSync(T entity, List<object> avoidedProperties)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.EditSync(entity, avoidedProperties);
            return true;
        }

        public void SaveChangesSync()
        {
            _repository.SaveChangesSync();
        }
    }

    public interface IOperationServices<T> where T : class
    {
        Task<T> Save(T entity);
        Task<T> Details(Expression<Func<T, bool>> predicate);
        Task<bool> Delete(T entity);
        Task<bool> DeleteRange(Expression<Func<T, bool>> predicate);
        Task<bool> IsExist(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<bool> Update(T entity, List<object> avoidedProperties);
        Task<int> SaveChanges();
        T DetailSync(Expression<Func<T, bool>> predicate);
        bool UpdateSync(T entity, List<object> avoidedProperties);
        void SaveChangesSync();

    }
}
