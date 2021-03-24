using Domain.Contracts;

namespace Domain.Models
{
    public class ArtistUpdateModel : ISongIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}