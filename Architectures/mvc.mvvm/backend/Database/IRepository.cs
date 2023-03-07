using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Database
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<Guid> Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetByIds(IEnumerable<Guid> ids);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        IRepository<T> Tracking();
    }
}