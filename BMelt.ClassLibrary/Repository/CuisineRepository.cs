using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly DatabaseContext _dbContext;

        public CuisineRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cuisine> GetCuisineAsync(Guid id)
        {
            return await _dbContext.Cuisines.FindAsync(id) ?? new Cuisine();
        }

        public async Task<IEnumerable<Cuisine>> GetCuisinesAsync()
        {
            return await _dbContext.Cuisines.ToListAsync();
        }

        public async Task<Cuisine> AddCuisineAsync(Cuisine cuisine)
        {
            _dbContext.Cuisines.Add(cuisine);
            await _dbContext.SaveChangesAsync();
            return cuisine;
        }

        public async Task<Cuisine> UpdateCuisineAsync(Cuisine cuisine)
        {
            var cuisineExist = _dbContext.Cuisines.Find(cuisine.Id);
            if (cuisineExist != null)
            {
                _dbContext.Update(cuisine);
                await _dbContext.SaveChangesAsync();
            }
            
            return cuisine;
        }

        public async Task<bool> DeleteCuisineAsync(Guid id)
        {
            var cuisineExist = _dbContext.Cuisines.Find(id);
            if (cuisineExist != null)
            {
                _dbContext.Remove(cuisineExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}