using BMelt.ClassLibrary.Models;

namespace BMelt.Data.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        public Task<IEnumerable<Recipe>> GetByCuisineAsync(Guid cuisineId);
    }
}
