using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IArtistGetService
    {
        Task ValidateAsync(IArtistContainer artistContainer);
        
        Task<Artist> GetAsync(IArtistContainer artistContainer);
        Task<IEnumerable<Artist>> GetAsync();
    }
}