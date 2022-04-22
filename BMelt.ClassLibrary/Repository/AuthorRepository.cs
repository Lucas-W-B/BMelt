using BMelt.ClassLibrary.Models;
using BMelt.ClassLibrary.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BMelt.ClassLibrary.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext _dbContext;

        public AuthorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetAuthorAsync(Guid id)
        {
            return await _dbContext.Authors.FindAsync(id) ?? new Author();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var authorExist = _dbContext.Authors.Find(author.Id);
            if (authorExist != null)
            {
                _dbContext.Update(author);
                await _dbContext.SaveChangesAsync();
            }
            
            return author;
        }

        public async Task<bool> DeleteAuthorAsync(Guid id)
        {
            var authorExist = _dbContext.Authors.Find(id);
            if (authorExist != null)
            {
                _dbContext.Authors.Remove(authorExist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
