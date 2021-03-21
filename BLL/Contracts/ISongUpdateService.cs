using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ISongUpdateService
    {
        Task<Song> UpdateAsync(SongUpdateModel song);
    }
}