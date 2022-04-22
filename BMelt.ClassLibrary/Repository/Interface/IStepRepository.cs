using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IStepRepository
    {
        public Task<Step> GetStepAsync(Guid id);
        public Task<IEnumerable<Step>> GetStepsAsync();
        public Task<Step> AddStepAsync(Step step);
        public Task<Step> UpdateStepAsync(Step step);
        public Task<bool> DeleteStepAsync(Guid id);
    }
}