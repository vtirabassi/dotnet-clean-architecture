using System.Linq.Expressions;
using Application.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().FirstOrDefaultAsync<T>(predicate) ?? (T)Activator.CreateInstance<T>();

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate)
        {
            if(predicate is null)
                return await _context.Set<T>().ToListAsync();

            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

