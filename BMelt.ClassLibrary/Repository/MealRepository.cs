using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly DatabaseContext _dbContext;

        public MealRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Meal> GetMealAsync(Guid id)
        {
            return await _dbContext.Meals.FindAsync(id) ?? new Meal();
        }

        public async Task<IEnumerable<Meal>> GetMealsAsync()
        {
            return await _dbContext.Meals.ToListAsync();
        }
        
        public async Task<Meal> AddMealAsync(Meal meal)
        {
            _dbContext.Meals.Add(meal);
            await _dbContext.SaveChangesAsync();
            return meal;
        }

        public async Task<Meal> UpdateMealAsync(Meal meal)
        {
            var mealExist = _dbContext.Meals.Find(meal.Id);
            if (mealExist != null)
            {
                _dbContext.Update(meal);
                await _dbContext.SaveChangesAsync();
            }
            
            return meal;
        }

        public async Task<bool> DeleteMealAsync(Guid id)
        {
            var mealExist = _dbContext.Meals.Find(meal.Id);
            if (mealExist != null)
            {
                _dbContext.Remove(meal);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}