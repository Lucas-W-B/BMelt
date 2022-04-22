using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IToolRepository
    {
        public Task<Tool> GetToolAsync(Guid id);
        public Task<IEnumerable<Tool>> GetToolsAsync();
        public Task<Tool> AddToolAsync(Tool tool);
        public Task<Tool> UpdateToolAsync(Tool tool);
        public Task<bool> DeleteToolAsync(Guid id);
    }
}