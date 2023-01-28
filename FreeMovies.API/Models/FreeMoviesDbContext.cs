using FreeMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models
{
    public class FreeMoviesDbContext: DbContext
    {
        public FreeMoviesDbContext(DbContextOptions<FreeMoviesDbContext> options)
            :base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}