using System.Collections.Generic;

namespace RazorWebApplication.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public ICollection<AlbumModel> Album { get; set; }
    }
}