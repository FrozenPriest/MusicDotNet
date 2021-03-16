using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IAlbumGetService
    {
        Task ValidateAsync(IAlbumContainer albumContainer);
    }
}