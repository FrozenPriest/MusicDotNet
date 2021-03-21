using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class SongUpdateService : ISongUpdateService
    {
        private ISongDataAccess SongDataAccess { get; }
        private IAlbumGetService AlbumGetService { get; }

        public SongUpdateService(ISongDataAccess songDataAccess, IAlbumGetService albumGetService)
        {
            SongDataAccess = songDataAccess;
            AlbumGetService = albumGetService;
        }

        public async Task<Song> UpdateAsync(SongUpdateModel song)
        {
            await AlbumGetService.ValidateAsync(song);
            return await SongDataAccess.UpdateAsync(song);
        }
    }
}