using Domain.Contracts;

namespace Domain.Models
{
    public class SongIdentityModel: ISongIdentity
    {
        public SongIdentityModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}