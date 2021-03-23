using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class AlbumUpdateService : IAlbumUpdateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }
        private IArtistGetService ArtistGetService { get; }

        public AlbumUpdateService(IAlbumDataAccess albumDataAccess, IArtistGetService artistGetService)
        {
            AlbumDataAccess = albumDataAccess;
            ArtistGetService = artistGetService;
        }

        public async Task<Album> UpdateAsync(AlbumUpdateModel album)
        {
            await ArtistGetService.ValidateAsync(album);
            return await AlbumDataAccess.UpdateAsync(album);
        }
    }
}