using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IAlbumDataAccess
    {
        Task<Album> GetByAsync(IAlbumContainer album);
        Task<IEnumerable<Album>> GetAsync();

        Task<Album> InsertAsync(AlbumUpdateModel album);
        Task<Album> UpdateAsync(AlbumUpdateModel album);
    }
}