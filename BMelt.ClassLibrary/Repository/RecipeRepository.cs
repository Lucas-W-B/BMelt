using BMelt.ClassLibrary.Enums;
using BMelt.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class RecipeRepository
    {
        private readonly DatabaseContext _dbContext;

        public RecipeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Recipe> GetRecipeAsync(Guid id)
        {
            return await _dbContext.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(Cuisine cuisine)
        {
            return await _dbContext.Recipes.Where(x => x.Cuisines.Any(c => c == cuisine)).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _dbContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
        {
            var productExist = _dbContext.Recipes.Find(recipe.Id);
            if (productExist != null)
            {
                _dbContext.Update(recipe);
                await _dbContext.SaveChangesAsync();
            }

            return recipe;
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}
