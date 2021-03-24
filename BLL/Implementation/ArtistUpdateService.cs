using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class ArtistUpdateService : IArtistUpdateService
    {
        private IArtistDataAccess ArtistDataAccess { get; }

        public ArtistUpdateService(IArtistDataAccess artistDataAccess)
        {
            ArtistDataAccess = artistDataAccess;
        }

        public async Task<Artist> UpdateAsync(ArtistUpdateModel artist)
        {
            return await ArtistDataAccess.UpdateAsync(artist);
        }
    }
}