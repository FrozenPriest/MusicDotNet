using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumModel>> GetAll();
        Task<AlbumModel> GetById(int id);
    }
}