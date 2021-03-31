using System.Collections.Generic;

namespace RazorWebApplication.Models
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            Song = new HashSet<SongModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ArtistModel Artist { get; set; }

        public IEnumerable<SongModel> Song { get; set; }
    }
}