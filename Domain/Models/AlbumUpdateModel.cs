using Domain.Contracts;

namespace Domain.Models
{
    public class AlbumUpdateModel : IArtistContainer, ISongIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int ArtistId { get; set; }
    }
}