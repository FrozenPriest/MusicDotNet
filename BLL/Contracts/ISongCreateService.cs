using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ISongCreateService
    {
        Task<Song> CreateAsync(SongUpdateModel song);
    }
}