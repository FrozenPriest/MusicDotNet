using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface ISongGetService
    {
        Task<IEnumerable<Song>> GetAsync();
        Task<Song> GetAsync(ISongIdentity employee);
    }
}