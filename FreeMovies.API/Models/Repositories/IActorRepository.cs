using FreeMovies.Models;

namespace FreeMovies.API.Models.Repositories;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetActors(); 
    Task<Actor> GetActor(int id); 
    Task<Actor> AddActor(Actor actor); 
    Task<Actor> UpdateActor(Actor actor); 
    void DeleteActor (int id);
}