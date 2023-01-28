using FreeMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly FreeMoviesDbContext _context ;
    public MovieRepository(FreeMoviesDbContext freeMoviesDbContext)
    {
        _context = freeMoviesDbContext;
    }

    public async Task<Movie> AddMovie(Movie movie)
    {
        var result = await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async void DeleteMovie(int id)
    {
       var result = await _context.Movies
            .FirstOrDefaultAsync(x => x.Id == id);
       if (result != null)
       {
            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();
       }
    }

    public async Task<Movie> GetMovie(int id)
    {
        return await _context.Movies
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        var existingMovie = await _context.Movies
            .FirstOrDefaultAsync(x => x.Id == movie.Id);
        if (existingMovie != null)
        {
            existingMovie.MovieTitle = movie.MovieTitle;
            existingMovie.Discription = movie.Discription;
            existingMovie.MovieVideoPath = movie.MovieVideoPath;
            existingMovie.PosterImagePath = movie.PosterImagePath;
            existingMovie.Year = movie.Year;
            existingMovie.UploadedDate = movie.UploadedDate;
            existingMovie.Country = movie.Country;
            existingMovie.Genres = movie.Genres;
            existingMovie.Comments = movie.Comments;
        }

        await _context.SaveChangesAsync();
        return existingMovie;
    }
}