using BrightMinds.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BrightMindsContext _context;

    public BookRepository(BrightMindsContext context)
    {
        _context = context;
    }

    public async Task<Book> AddBook(Book book)
    {
        var _book = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return _book.Entity;
    }

    public void DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> GetBook(int id)
    {
        return await _context.Books.Include(o => o.Author)
            .FirstOrDefaultAsync(x => x.BookId == id);
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public Task<Book> UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

}
