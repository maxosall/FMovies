using System.ComponentModel.DataAnnotations;

namespace FreeMovies.Models;
public class SocialMediaAccount
{
    [Key]
    public int Id { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string LinkedIn { get; set; }
}