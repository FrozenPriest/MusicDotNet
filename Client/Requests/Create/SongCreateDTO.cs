using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class SongCreateDTO
    {
        [Required(ErrorMessage = "Song name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Album is required")]
        public int AlbumId { get; set; }
        
    }
}