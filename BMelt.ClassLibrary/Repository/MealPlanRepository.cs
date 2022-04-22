using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly DatabaseContext _dbContext;

        public MealPlanRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MealPlan> GetMealPlanAsync(Guid id)
        {
            return await _dbContext.MealPlans.FindAsync(id) ?? new MealPlan();
        }

        public async Task<IEnumerable<MealPlan>> GetMealPlansAsync()
        {
            return await _dbContext.MealPlans.ToListAsync();
        }
        
        public async Task<MealPlan> AddMealPlanAsync(MealPlan plan)
        {
            _dbContext.MealPlans.Add(plan);
            await _dbContext.SaveChangesAsync();
            return plan;
        }

        public async Task<MealPlan> UpdateMealPlanAsync(MealPlan plan)
        {
            var planExist = _dbContext.MealPlans.Find(plan.Id);
            if (planExist != null)
            {
                _dbContext.Update(plan);
                await _dbContext.SaveChangesAsync();
            }
            
            return plan;
        }

        public async Task<bool> DeleteMealPlanAsync(Guid id)
        {
            var planExist = _dbContext.MealPlans.Find(plan.Id);
            if (planExist != null)
            {
                _dbContext.Remove(plan);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}