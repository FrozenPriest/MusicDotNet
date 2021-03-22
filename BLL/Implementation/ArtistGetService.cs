using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using DataAccess.Implementations;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class ArtistGetService: IArtistGetService
    {
        private IArtistDataAccess ArtistDataAccess { get; }

        public ArtistGetService(IArtistDataAccess artistDataAccess)
        {
            ArtistDataAccess = artistDataAccess;
        }
        
        public async Task ValidateAsync(IArtistIdentity artistIdentity)
        {
            if (artistIdentity == null) throw new ArgumentNullException(nameof(artistIdentity));

            var album = await GetBy(artistIdentity);

            if (album == null)
            {
                throw new InvalidOperationException($"Album with id {artistIdentity.ArtistId} not found");
            }
            
        }

        private async Task<Artist> GetBy(IArtistIdentity artistIdentity)
        {
            return await ArtistDataAccess.GetByAsync(artistIdentity);
        }
    }
}