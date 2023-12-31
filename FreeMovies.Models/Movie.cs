using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models;

public class Movie
{
    [Key]
    [Column("MovieId")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)"), MaxLength(150)]
    public string MovieTitle { get; set; }

    [Column(TypeName = "nvarchar(300)"), MaxLength(300)]
    public string Discription { get; set; }

    [Required, Display(Name = "Movie Video Path")]
    public string MovieVideoPath { get; set; }

    [Display(Name = "Poster Image")]
    [Required]
    public string PosterImagePath { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime UploadedDate { get; set; }

    [Display(Name = "Released Date"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime? Year { get; set; }

    public virtual Country? Country { get; set; } = new Country();
    public virtual List<Genre>? Genres { get; set; }

    public virtual List<Actor>? Actors { get; set; }
    public virtual List<Comment>? Comments { get; set; } = new List<Comment>();
}