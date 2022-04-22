using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorAsync(Guid id);
        public Task<IEnumerable<Author>> GetAuthorsAsync();
        public Task<Author> AddAuthorAsync(Author author);
        public Task<Author> UpdateAuthorAsync(Author author);
        public Task<bool> DeleteAuthorAsync(Guid id);
    }
}
