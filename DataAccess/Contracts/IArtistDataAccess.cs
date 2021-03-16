using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace DataAccess.Contracts
{
    public interface IArtistDataAccess
    {
        Task<Artist> GetByAsync(IArtistIdentity artist);
    }
}