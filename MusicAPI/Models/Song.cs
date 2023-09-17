using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        [Required(ErrorMessage = "ImageURL cannot be null or empty!")]
        public DateTime UploadedDate { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageURL { get; set; }
        public string? AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
