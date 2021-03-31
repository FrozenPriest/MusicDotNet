using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface ISongService
    {
        Task<IEnumerable<SongModel>> GetAll();
        Task<SongModel> GetById(int id);
        Task DeleteById(int id);
    }
}