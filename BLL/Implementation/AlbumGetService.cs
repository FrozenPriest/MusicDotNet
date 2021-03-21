using System;
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

            var album = await GetBy(albumContainer);

            if (albumContainer.AlbumId.HasValue && album == null)
            {
                throw new InvalidOperationException($"Album with id {albumContainer.AlbumId} not found");
            }
            
        }

        private async Task<Album> GetBy(IAlbumContainer albumContainer)
        {
            return await AlbumDataAccess.GetByAsync(albumContainer);
        }
    }
}