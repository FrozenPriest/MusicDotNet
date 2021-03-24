using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface ISongDeleteService
    {
        Task DeleteAsync(ISongIdentity song);
    }
}