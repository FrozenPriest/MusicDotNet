using Domain.Contracts;

namespace Domain.Models
{
    public class SongUpdateModel : ISongIdentity, IAlbumContainer
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public int? AlbumId { get; set; }
    }
}