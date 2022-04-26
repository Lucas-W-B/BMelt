
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class ItemRepository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;

        public ItemRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<T> GetAsync(Guid id)
        {
            return await _dbContext.FindAsync<T>(id) ?? Activator.CreateInstance(typeof(T)) as T ?? throw new KeyNotFoundException();
        }
        
        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        
        public async Task<Guid> AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return typeof(T).GetProperty("Id")?.GetValue(item) as Guid? ?? Guid.Empty;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _dbContext.Update(item);
            await _dbContext.SaveChangesAsync();
            
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var itemExist = await _dbContext.FindAsync<T>(id);
            if (itemExist != null)
            {
                _dbContext.Remove(itemExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
