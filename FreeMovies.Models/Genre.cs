using System.ComponentModel.DataAnnotations;

namespace FreeMovies.Models;
public class Genre
{    
    public int Id { get; set; }
    [MaxLength(50)]
    public string GenreTitle { get; set; }
    public ICollection<Movie>? Movies { get; set; } 
    // public ICollection<TVSeries>? TV_Series { get; set; } 
}

// public enum Genre
// {
//     Action,
//     Adventure,
//     Animation,
//     Biography,
//     Costume, 
//     Comedy,
//     Crime,
//     Documantary,
//     Drama,
//     Family,
//     Fantacy,
//     GameShow,
//     History,
//     Horror,
//     Kunfu,
//     Music,
//     Mystry,
//     RealityTV,
//     Romance,
//     SciFi,
//     Sport,
//     Thirller,
//     War,
//     Westren,
// }
