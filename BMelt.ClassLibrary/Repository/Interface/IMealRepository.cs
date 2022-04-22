using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IMealRepository
    {
        public Task<Meal> GetMealAsync(Guid id);
        public Task<IEnumerable<Meal>> GetMealsAsync();
        public Task<Meal> AddMealAsync(Meal meal);
        public Task<Meal> UpdateMealAsync(Meal meal);
        public Task<bool> DeleteMealAsync(Guid id);
    }
}