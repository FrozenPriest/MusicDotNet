using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class ArtistGetService : IArtistGetService
    {
        private IArtistDataAccess ArtistDataAccess { get; }

        public ArtistGetService(IArtistDataAccess artistDataAccess)
        {
            ArtistDataAccess = artistDataAccess;
        }

        public async Task ValidateAsync(IArtistContainer artistContainer)
        {
            if (artistContainer == null) throw new ArgumentNullException(nameof(artistContainer));

            var album = await GetAsync(artistContainer);

            if (album == null)
            {
                throw new InvalidOperationException($"Album with id {artistContainer.ArtistId} not found");
            }
        }

        public async Task<IEnumerable<Artist>> GetAsync()
        {
            return await ArtistDataAccess.GetAsync();
        }

        public async Task<Artist> GetAsync(IArtistContainer artistContainer)
        {
            return await ArtistDataAccess.GetByAsync(artistContainer);
        }
    }
}