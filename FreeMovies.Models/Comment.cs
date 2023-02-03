using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models;

public class Comment
{
    [Key]
    [Column("CommentId")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(300)"), MaxLength(300)]
    public string CommentContent { get; set; }

    [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime DateCreated { get; init; } = DateTime.Now;

    [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime DateModefied { get; set; } = DateTime.Now;
    public virtual ICollection<Movie>? Movies { get; set; }
    // public virtual ICollection<TVSeries> TV_Series { get; set; }
}