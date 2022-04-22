using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IRecipeRepository
    {
        public Task<Recipe> GetRecipeAsync(Guid id);
        public Task<IEnumerable<Recipe>> GetRecipesAsync();
        public Task<Recipe> AddRecipeAsync(Recipe recipe);
        public Task<Recipe> UpdateRecipeAsync(Recipe recipe);
        public Task<bool> DeleteRecipeAsync(Guid id);
    }
}