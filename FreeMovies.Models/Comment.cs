using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models;

public class Comment
{
    [Column("CommentId")]    
    public int Id { get; set; }
    
    [Required]
    [MaxLength(300)]
    [DataType("nvarchar")]
    public string CommentContent { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.DateTime)]
    public DateTime DateCreated { get; init; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.DateTime)]
    public DateTime DateModefied { get; set; } = DateTime.Now;
    public virtual ICollection<Movie>? Movies { get; set; } 
    // public virtual ICollection<TVSeries> TV_Series { get; set; }
}