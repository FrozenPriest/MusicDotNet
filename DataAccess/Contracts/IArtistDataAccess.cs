using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IArtistDataAccess
    {
        Task<Artist> GetByAsync(IArtistContainer artist);
        Task<IEnumerable<Artist>> GetAsync();
        
        Task<Artist> InsertAsync(ArtistUpdateModel artist);
        Task<Artist> UpdateAsync(ArtistUpdateModel artist);
    }
}