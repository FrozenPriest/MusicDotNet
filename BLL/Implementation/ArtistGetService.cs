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
        
        public async Task ValidateAsync(IArtistContainer artistContainer)
        {
            if (artistContainer == null) throw new ArgumentNullException(nameof(artistContainer));

            var album = await GetBy(artistContainer);

            if (album == null)
            {
                throw new InvalidOperationException($"Album with id {artistContainer.ArtistId} not found");
            }
            
        }

        private async Task<Artist> GetBy(IArtistContainer artistContainer)
        {
            return await ArtistDataAccess.GetByAsync(artistContainer);
        }
    }
}