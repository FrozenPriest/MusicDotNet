using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class SongCreateService: ISongCreateService
    {
        private ISongDataAccess SongDataAccess { get; }
        private IAlbumGetService AlbumGetService { get; }

        public SongCreateService(ISongDataAccess songDataAccess, IAlbumGetService albumGetService)
        {
            SongDataAccess = songDataAccess;
            AlbumGetService = albumGetService;
        }

        public async Task<Song> CreateAsync(SongUpdateModel song)
        {
            await AlbumGetService.ValidateAsync(song);
            return await SongDataAccess.InsertAsync(song);
        }
    }
}