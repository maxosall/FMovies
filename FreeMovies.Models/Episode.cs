using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models;

public class Episode
{
    [Column("EpisodeId")]
    public int Id { get; set; }

    [MaxLength(150)]
    public string EpisodeTitle { get; set; }

    [MaxLength(300)]
    public string? EpisodeDescription { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime UploadedDate { get; set; }
    public string EpisodeVideoPath { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}