using System.Collections.Generic;
using Domain.Contracts;

namespace Domain
{
    public class Album : IArtistContainer, IAlbumIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public Artist Artist;


        public IEnumerable<Song> Song { get; set; }

        int IArtistContainer.ArtistId => this.Artist.Id;
    }
}