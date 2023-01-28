using System.ComponentModel.DataAnnotations;

namespace FreeMovies.Models;

public class Season
{
    [MaxLength(50)]
    public string SeasonName { get; set; }
    public virtual ICollection<Episode> Episodes { get; set; }
    public string PosterImagePath { get; set; }
}
