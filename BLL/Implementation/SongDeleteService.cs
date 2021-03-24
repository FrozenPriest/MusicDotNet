using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class SongDeleteService:ISongDeleteService
    {
        private ISongDataAccess SongDataAccess { get; }

        public SongDeleteService(ISongDataAccess songDataAccess)
        {
            SongDataAccess = songDataAccess;
        }

        public Task DeleteAsync(ISongIdentity song)
        {
            return SongDataAccess.DeleteAsync(song);
        }
    }
}