using BMelt.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class RecipeRepository : ItemRepository<Recipe>, IRecipeRepository
    {
        private readonly DatabaseContext _dbContext;

        public RecipeRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAsync(Cuisine cuisine)
        {
            return await _dbContext.Recipes.Where(x => x.Cuisines.Any(c => c.Id == cuisine.Id)).ToListAsync();
        }

    }
}
