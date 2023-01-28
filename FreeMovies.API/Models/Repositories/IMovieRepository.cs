using FreeMovies.Models;

namespace FreeMovies.API.Models.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMovies(); 
    Task<Movie> GetMovie(int id); 
    Task<Movie> AddMovie(Movie movie); 
    Task<Movie> UpdateMovie(Movie movie); 
    void DeleteMovie (int id);
}