using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class ArtistCreateDTO
    {
        [Required(ErrorMessage = "Artist name is required")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}