using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
        public int ArtistId { get; set; }
        public List<Song> Songs { get; set; }
    }
}
