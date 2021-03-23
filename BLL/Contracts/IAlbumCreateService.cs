using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IAlbumCreateService
    {
        Task<Album> CreateAsync(AlbumUpdateModel song);
    }
}