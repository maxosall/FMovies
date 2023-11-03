using BrightMinds.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BrightMindsContext _context;

        public AuthorRepository(BrightMindsContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            var result = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(x => x.AuthorId == id);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public Task<Author> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

    }
}