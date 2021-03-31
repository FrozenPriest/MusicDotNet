using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistModel>> GetAll();
        Task<ArtistModel> GetById(int id);
    }
}