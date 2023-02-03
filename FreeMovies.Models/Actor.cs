using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeMovies.Models
{
    public class Actor
    {
        [Key]
        [Column("ActorId")]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [Column(TypeName = "varchar(50)"), Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required, MaxLength(50)]
        [Column(TypeName = "varchar(50)"), Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [MaxLength(350)]
        [Column(TypeName = "nvarchar(350)")]
        public string? Bio { get; set; }
        public SocialMediaAccount? SocialMediaAccounts { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }
        public virtual List<Movie>? Movies { get; set; }

        // public virtual ICollection<TVSeries>? Series { get; set; }

        // public override string ToString() => $"{FirstName} {LastName}";

    }
}