using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class NutritionFactRepository : INutritionFactRepository
    {
        private readonly DatabaseContext _dbContext;

        public NutritionFactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NutritionFact> GetNutritionFactAsync(Guid id)
        {
            return await _dbContext.NutritionFacts.FindAsync(id) ?? new NutritionFact();
        }

        public async Task<IEnumerable<NutritionFact>> GetNutritionFactsAsync()
        {
            return await _dbContext.NutritionFacts.ToListAsync();
        }
        
        public async Task<NutritionFact> AddNutritionFactAsync(NutritionFact fact)
        {
            _dbContext.NutritionFacts.Add(fact);
            await _dbContext.SaveChangesAsync();
            return fact;
        }

        public async Task<NutritionFact> UpdateNutritionFactAsync(NutritionFact fact)
        {
            var factExist = _dbContext.NutritionFacts.Find(fact.Id);
            if (factExist != null)
            {
                _dbContext.Update(fact);
                await _dbContext.SaveChangesAsync();
            }
            
            return fact;
        }

        public async Task<bool> DeleteNutritionFactAsync(Guid id)
        {
            var factExist = _dbContext.NutritionFacts.Find(fact.Id);
            if (factExist != null)
            {
                _dbContext.Remove(fact);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}