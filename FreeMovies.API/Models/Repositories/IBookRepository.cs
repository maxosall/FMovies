using BrightMinds.Models;

namespace FreeMovies.API.Models.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book> GetBook(int id);
    Task<Book> AddBook(Book book);
    Task<Book> UpdateBook(Book book);
    void DeleteBook(int id);
}