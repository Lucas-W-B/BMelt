using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class StepRepository : IStepRepository
    {
        private readonly DatabaseContext _dbContext;

        public StepRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Step> GetStepAsync(Guid id)
        {
            return await _dbContext.Steps.FindAsync(id) ?? new Step();
        }

        public async Task<IEnumerable<Step>> GetStepsAsync()
        {
            return await _dbContext.Steps.ToListAsync();
        }
        
        public async Task<Step> AddStepAsync(Step step)
        {
            _dbContext.Steps.Add(step);
            await _dbContext.SaveChangesAsync();
            return step;
        }

        public async Task<Step> UpdateStepAsync(Step step)
        {
            var stepExist = _dbContext.Steps.Find(step.Id);
            if (stepExist != null)
            {
                _dbContext.Update(step);
                await _dbContext.SaveChangesAsync();
            }
            
            return step;
        }

        public async Task<bool> DeleteStepAsync(Guid id)
        {
            var stepExist = _dbContext.Steps.Find(id);
            if (stepExist != null)
            {
                _dbContext.Remove(stepExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}