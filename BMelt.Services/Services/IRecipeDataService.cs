using BMelt.ClassLibrary.Models;

namespace BMelt.Services.Services
{
    public interface IRecipeDataService : IItemDataService<Recipe>
    {
        public Task<IEnumerable<Recipe>> GetByCuisineAsync(Guid cuisineId);
    }
}
