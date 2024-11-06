using managementorderapi.Data;
using Microsoft.EntityFrameworkCore;

namespace managementorderapi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

        public async Task<T> GetById(int id) => await _entities.FindAsync(id);

        public async Task Add(T entity) => await _entities.AddAsync(entity);

        public async Task Update(T entity) =>  _entities.Update(entity);

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
                _entities.Remove(entity);
        }

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
