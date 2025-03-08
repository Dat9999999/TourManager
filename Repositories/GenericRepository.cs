using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TourManagerment.Data;

namespace TourManagerment.Repositories
{
    public class GenericRepository<T> where T : class
    {
        protected readonly MTourContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new MTourContext();
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync(); // Không lấy từ cache
        }


        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var trackedEntity = await _dbSet.FindAsync(_context.Entry(entity).Property("Id").CurrentValue);
            if (trackedEntity != null)
            {
                _context.Entry(trackedEntity).State = EntityState.Detached; // Tách entity cũ ra khỏi DbContext
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }





        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
