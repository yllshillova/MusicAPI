using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be null or empty!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Language cannot be null or empty!")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Duration cannot be null or empty!")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "ImageURL cannot be null or empty!")]
        public string ImageURL { get; set; }
    }
}
