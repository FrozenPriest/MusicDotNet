using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IAlbumGetService
    {
        Task ValidateAsync(IAlbumContainer albumContainer);
        Task<Album> GetAsync(IAlbumContainer albumContainer);
        Task<IEnumerable<Album>> GetAsync();
    }
}