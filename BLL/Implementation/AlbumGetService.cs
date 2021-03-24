using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class AlbumGetService : IAlbumGetService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }

        public AlbumGetService(IAlbumDataAccess albumDataAccess)
        {
            AlbumDataAccess = albumDataAccess;
        }

        public async Task ValidateAsync(IAlbumContainer albumContainer)
        {
            if (albumContainer == null) throw new ArgumentNullException(nameof(albumContainer));

            var album = await GetAsync(albumContainer);

            if (album == null)
            {
                throw new InvalidOperationException($"Album with id {albumContainer.AlbumId} not found");
            }
        }

        public async Task<Album> GetAsync(IAlbumContainer albumContainer)
        {
            return await AlbumDataAccess.GetByAsync(albumContainer);
        }

        public async Task<IEnumerable<Album>> GetAsync()
        {
            return await AlbumDataAccess.GetAsync();
        }
    }
}