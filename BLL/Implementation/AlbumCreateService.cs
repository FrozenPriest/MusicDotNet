using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class AlbumCreateService : IAlbumCreateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }
        private IArtistGetService ArtistGetService { get; }

        public AlbumCreateService(IAlbumDataAccess albumDataAccess, IArtistGetService artistGetService)
        {
            AlbumDataAccess = albumDataAccess;
            ArtistGetService = artistGetService;
        }

        public async Task<Album> CreateAsync(AlbumUpdateModel album)
        {
            await ArtistGetService.ValidateAsync(album);
            return await AlbumDataAccess.InsertAsync(album);
        }
    }
}