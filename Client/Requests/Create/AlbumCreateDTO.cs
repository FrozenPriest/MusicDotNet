using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class AlbumCreateDTO
    {
        [Required(ErrorMessage = "Album name is required")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Artist id is required")]
        public int ArtistId { get; set; }
    }
}