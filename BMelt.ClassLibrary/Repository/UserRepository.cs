using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id) ?? new User();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        
        public async Task<User> AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userExist = _dbContext.Users.Find(user.Id);
            if (userExist != null)
            {
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var userExist = _dbContext.Users.Find(id);
            if (userExist != null)
            {
                _dbContext.Remove(userExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}