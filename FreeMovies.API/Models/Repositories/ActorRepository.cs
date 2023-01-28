using FreeMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models.Repositories;

public class ActorRepository : IActorRepository
{
    private readonly FreeMoviesDbContext _context;
    public ActorRepository(FreeMoviesDbContext freeMoviesDbContext)
    {
        _context = freeMoviesDbContext;
    }


    public async Task<Actor> AddActor(Actor actor)
    {
        var result = await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async void DeleteActor(int id)
    {
        var result = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);
        if (result != null)
        {
             _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Actor> GetActor(int id) => await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Actor>> GetActors()
    {
        return await _context.Actors.ToListAsync();
    }

    public async Task<Actor> UpdateActor(Actor actor)
    {
        var existingActor = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == actor.Id);

        if (existingActor != null)
        {
            existingActor.FirstName = actor.FirstName;
            existingActor.LastName = actor.LastName;
            existingActor.Bio = actor.Bio;
            existingActor.DateOfBirth = actor.DateOfBirth;
            existingActor.Movies = actor.Movies;
        }
        await _context.SaveChangesAsync();
        return existingActor;
    }
}