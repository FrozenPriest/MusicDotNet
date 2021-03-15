using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface ISongDataAccess
    {
        Task<IEnumerable<Song>> GetAsync();
        Task<Song> GetAsync(ISongIdentity songId);

        Task<Song> InsertAsync(SongUpdateModel song);
        Task<Song> UpdateAsync(SongUpdateModel song);
    }
}