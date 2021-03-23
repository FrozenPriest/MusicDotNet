
using System.Collections.Generic;

namespace Client.DTO.Read
{
    public class AlbumDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ArtistDTO Artist { get; set; }
        public IEnumerable<SongDTO> Song { get; set; }
    }
}