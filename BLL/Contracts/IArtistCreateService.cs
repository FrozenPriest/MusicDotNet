using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IArtistCreateService
    {
        Task<Artist> CreateAsync(ArtistUpdateModel artist);
    }
}