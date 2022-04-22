using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IMealPlanRepository
    {
        public Task<MealPlan> GetMealPlanAsync(Guid id);
        public Task<IEnumerable<MealPlan>> GetMealPlansAsync();
        public Task<MealPlan> AddMealPlanAsync(MealPlan plan);
        public Task<MealPlan> UpdateMealPlanAsync(MealPlan plan);
        public Task<bool> DeleteMealPlanAsync(Guid id);
    }
}