using System;
using Domain.Contracts;

namespace Domain
{
    public class Song: IAlbumContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Album Album { get; set; }

        int IAlbumContainer.AlbumId => this.Album.Id;
    }
}