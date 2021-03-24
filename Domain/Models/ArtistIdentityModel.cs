using Domain.Contracts;

namespace Domain.Models
{
    public class ArtistIdentityModel : IArtistContainer
    {
        public ArtistIdentityModel(int artistId)
        {
            ArtistId = artistId;
        }

        public int ArtistId { get; }
    }
}