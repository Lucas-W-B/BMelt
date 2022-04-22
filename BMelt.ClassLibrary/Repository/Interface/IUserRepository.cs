using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(Guid id);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> AddUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(Guid id);
    }
}