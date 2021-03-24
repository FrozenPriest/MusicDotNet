using System.Collections.Generic;

namespace Client.DTO.Read
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public IEnumerable<AlbumDTO> Album { get; set; }

    }
}