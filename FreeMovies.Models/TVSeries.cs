using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models;

public class TVSeries
{
    [Column("TVShowId")]
    public int Id { get; set; }

    [Required, DataType("nvarchar"), MaxLength(150)]
    public string Name { get; set; }

    [MaxLength(130)]
    public string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime Year { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Season> Seasons { get; set; }
}