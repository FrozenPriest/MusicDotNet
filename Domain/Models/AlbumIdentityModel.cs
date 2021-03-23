using Domain.Contracts;

namespace Domain.Models
{
    public class AlbumIdentityModel:IAlbumContainer
    {
        public AlbumIdentityModel(int albumId)
        {
            AlbumId = albumId;
        }

        public int AlbumId { get; }
    }
}