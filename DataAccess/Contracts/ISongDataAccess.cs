using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface ISongDataAccess
    {
        Task<Song> GetAsync(ISongIdentity songId);
        Task<IEnumerable<Song>> GetAsync(IAlbumIdentity albumId);
        
        Task<Song> InsertAsync(SongUpdateModel song);
        Task<Song> UpdateAsync(SongUpdateModel song);
    }
}