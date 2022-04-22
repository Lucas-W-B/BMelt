using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface INutritionFactRepository
    {
        public Task<NutritionFact> GetNutritionFactAsync(Guid id);
        public Task<IEnumerable<NutritionFact>> GetNutritionFactsAsync();
        public Task<NutritionFact> AddNutritionFactAsync(NutritionFact fact);
        public Task<NutritionFact> UpdateNutritionFactAsync(NutritionFact fact);
        public Task<bool> DeleteNutritionFactAsync(Guid id);
    }
}