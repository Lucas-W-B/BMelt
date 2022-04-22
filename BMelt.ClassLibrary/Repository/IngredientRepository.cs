using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DatabaseContext _dbContext;

        public IngredientRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ingredient> GetIngredientAsync(Guid id)
        {
            return await _dbContext.Ingredients.FindAsync(id) ?? new Ingredient();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }
        
        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            var ingredientExist = _dbContext.Ingredients.Find(ingredient.Id);
            if (ingredientExist != null)
            {
                _dbContext.Update(ingredient);
                await _dbContext.SaveChangesAsync();
            }
            
            return ingredient;
        }
        
        public async Task<bool> DeleteIngredientAsync(Guid id)
        {
            var ingredientExist = _dbContext.Ingredients.Find(ingredient.Id);
            if (ingredientExist != null)
            {
                _dbContext.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}