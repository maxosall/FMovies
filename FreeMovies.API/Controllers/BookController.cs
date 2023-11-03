using BrightMinds.Models;
using FreeMovies.API.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FreeMovies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    [HttpGet]
    public async Task<ActionResult> GetBooks()
    {
        try
        {
            return Ok(await _bookRepository.GetBooks());
        }
        catch (Exception)
        {
            return StatusCodeMessage();
        }
    }

    private ObjectResult StatusCodeMessage(string err_msg = "Error retrieving data from database ")
    {
        return StatusCode(StatusCodes.Status500InternalServerError, err_msg);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        try
        {
            var result = await _bookRepository.GetBook(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        catch (Exception)
        {
            return StatusCodeMessage();
        }
    }

    [HttpPost]
    public async Task<ActionResult<Book>> AddBook(Book book)
    {
        try
        {
            if (book is null) return BadRequest();

            var addedBook = await _bookRepository.AddBook(book);

            return CreatedAtAction(nameof(GetBook),
                new { id = addedBook.AuthorId },
                addedBook);
        }
        catch (Exception)
        {
            return StatusCodeMessage("Error ADDING DATA To the database");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Book>> Update(int id, Book book)
    {
        try
        {
            if (id != book.BookId) return BadRequest("Book Id Mismatch");

            var bookToUpdate = await _bookRepository.GetBook(id);

            if (bookToUpdate == null)
                return NotFound($"Article with id= {id} is not founf");

            return await _bookRepository.UpdateBook(book);
        }
        catch (Exception)
        {
            return StatusCodeMessage("Error UPDATIG data on database");
        }
    }
}