using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IAlbumUpdateService
    {
        Task<Album> UpdateAsync(AlbumUpdateModel album);
    }
}