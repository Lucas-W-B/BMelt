using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class ToolRepository : IToolRepository
    {
        private readonly DatabaseContext _dbContext;

        public ToolRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tool> GetToolAsync(Guid id)
        {
            return await _dbContext.Tools.FindAsync(id) ?? new Tool();
        }

        public async Task<IEnumerable<Tool>> GetToolsAsync()
        {
            return await _dbContext.Tools.ToListAsync();
        }
        
        public async Task<Tool> AddToolAsync(Tool tool)
        {
            _dbContext.Tools.Add(tool);
            await _dbContext.SaveChangesAsync();
            return tool;
        }

        public async Task<Tool> UpdateToolAsync(Tool tool)
        {
            var toolExist = _dbContext.Tools.Find(tool.Id);
            if (toolExist != null)
            {
                _dbContext.Update(tool);
                await _dbContext.SaveChangesAsync();
            }
            
            return tool;
        }

        public async Task<bool> DeleteToolAsync(Guid id)
        {
            var toolExist = _dbContext.Tools.Find(id);
            if (toolExist != null)
            {
                _dbContext.Remove(toolExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}