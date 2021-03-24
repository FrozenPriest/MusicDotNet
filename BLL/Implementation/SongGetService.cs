using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class SongGetService : ISongGetService
    {
        private ISongDataAccess SongDataAccess { get; }

        public SongGetService(ISongDataAccess songDataAccess)
        {
            SongDataAccess = songDataAccess;
        }

        public Task<IEnumerable<Song>> GetAsync()
        {
            return SongDataAccess.GetAsync();
        }

        public Task<Song> GetAsync(ISongIdentity song)
        {
            return SongDataAccess.GetAsync(song);
        }
    }
}