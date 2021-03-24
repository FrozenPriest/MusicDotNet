using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class ArtistCreateService : IArtistCreateService
    {
        private IArtistDataAccess ArtistDataAccess  { get; }

        public ArtistCreateService(IArtistDataAccess artistDataAccess)
        {
            ArtistDataAccess = artistDataAccess;
        }

        public async Task<Artist> CreateAsync(ArtistUpdateModel artist)
        {
            return await ArtistDataAccess.InsertAsync(artist);
        }
    }
}