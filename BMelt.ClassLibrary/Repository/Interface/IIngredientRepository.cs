using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IIngredientRepository
    {
        public Task<Ingredient> GetIngredientAsync(Guid id);
        public Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        public Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
        public Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        public Task<bool> DeleteIngredientAsync(Guid id);
    }
}