using System.Collections.Generic;
using Domain.Contracts;

namespace Domain
{
    public class Artist: IArtistIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public ICollection<Album> Album { get; set; }
    }
}