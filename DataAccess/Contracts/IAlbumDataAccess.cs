using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace DataAccess.Contracts
{
    public interface IAlbumDataAccess
    {
        Task<Album> GetByAsync(IAlbumContainer album);
        
    }
}