using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeMovies.API.Models.Repositories;
using FreeMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeMovies.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController : ControllerBase
{
    private readonly IActorRepository _actorRepository;

    public ActorsController(IActorRepository actorRepository) => _actorRepository = actorRepository;

    [HttpGet]
    public async Task<ActionResult> GetActors()
    {
        try
        {
            return Ok( await _actorRepository.GetActors());
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
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
        try
        {
            var result = await _actorRepository.GetActor(id);
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
    public async Task<ActionResult<Actor>> AddActor(Actor actor)
    {
        try
        {
            if(actor is null ) return BadRequest();

            var addedActor = await _actorRepository.AddActor(actor);

            return CreatedAtAction(nameof(GetActor),
                new {id = addedActor.Id},
                addedActor);
        }
        catch (System.Exception)
        {
            return StatusCodeMessage("Error ADDING DATA To the database");
        }
    }
}