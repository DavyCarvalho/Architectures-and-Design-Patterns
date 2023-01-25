using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;
        private readonly DbSet<T> _db;

        public Repository(Context context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task<Guid> Add(T entity) 
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;

            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task AddRange(IEnumerable<T> entities) {
            await _db.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await _db.ToListAsync();

        public async Task<T> GetById(Guid id)
            => await _db.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<T>> GetByIds(IEnumerable<Guid> ids)
            => await _db.Where(e => ids.Contains(e.Id)).ToListAsync();

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
            => await _db.AnyAsync(predicate);

        public void Remove(T entity) 
        {
            _db.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
            _context.SaveChangesAsync();
        }

        public void Update(T entity) 
        {
            _db.Update(entity);
            _context.SaveChangesAsync();
        }

        public void UpdateRange(IEnumerable<T> entities) 
        {
            _db.UpdateRange(entities);
            _context.SaveChangesAsync();
        }

        public IRepository<T> Tracking()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

            return this;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) =>
            _context.Dispose();
    }
}