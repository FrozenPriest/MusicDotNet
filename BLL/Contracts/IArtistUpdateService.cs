using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IArtistUpdateService
    {
        Task<Artist> UpdateAsync(ArtistUpdateModel artist);
    }
}