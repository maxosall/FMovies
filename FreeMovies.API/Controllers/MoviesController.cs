using FreeMovies.API.Models.Repositories;
using FreeMovies.Models;
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FreeMovies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;
   
    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetMovies()
    {
        try
        {
            return Ok( await _movieRepository.GetMovies());
        }
        catch (Exception)
        {
            return StatusCodeMessage();
        }
    }

    private ObjectResult StatusCodeMessage(string err_msg = "Error retrieving data from database ")
    {
        return StatusCode(StatusCodes.Status500InternalServerError,  err_msg);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        try
        {
            var result = await _movieRepository.GetMovie(id);
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
    public async Task<ActionResult<Movie>> AddMovie(Movie movie)
    {
        try
        {
            if(movie is null ) return BadRequest();

            var addedMovie = await _movieRepository.AddMovie(movie);

            return CreatedAtAction(nameof(GetMovie),
                new {id = addedMovie.Id},
                addedMovie);
        }
        catch (System.Exception)
        {
            return StatusCodeMessage("Error ADDING DATA To the database");
        }
    }
}