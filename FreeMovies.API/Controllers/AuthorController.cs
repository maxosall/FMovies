using BrightMinds.Models;
using FreeMovies.API.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FreeMovies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    [HttpGet]
    public async Task<ActionResult> GetAuthors()
    {
        try
        {
            return Ok(await _authorRepository.GetAuthors());
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
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        try
        {
            var result = await _authorRepository.GetAuthor(id);
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
    public async Task<ActionResult<Author>> AddAuthor(Author author)
    {
        try
        {
            if (author is null) return BadRequest();

            var addedAuthor = await _authorRepository.AddAuthor(author);

            return CreatedAtAction(nameof(GetAuthor),
                new { id = addedAuthor.AuthorId },
                addedAuthor);
        }
        catch (Exception)
        {
            return StatusCodeMessage("Error ADDING DATA To the database");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Author>> Update(int id, Author author)
    {
        try
        {
            if (id != author.AuthorId) return BadRequest("Author Id Mismatch");

            var authorToUpdate = await _authorRepository.GetAuthor(id);

            if (authorToUpdate == null)
                return NotFound($"Article with id= {id} is not founf");

            return await _authorRepository.UpdateAuthor(author);
        }
        catch (Exception)
        {
            return StatusCodeMessage("Error UPDATIG data on database");
        }
    }
}