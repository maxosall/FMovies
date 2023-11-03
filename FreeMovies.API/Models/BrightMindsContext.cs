using BrightMinds.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeMovies.API.Models;

public class BrightMindsContext : DbContext
{
    public BrightMindsContext(DbContextOptions<BrightMindsContext> options)
        : base(options)
    { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}