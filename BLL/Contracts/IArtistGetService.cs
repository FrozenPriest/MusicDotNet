using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IArtistGetService
    {
        Task ValidateAsync(IArtistIdentity artistIdentity);

    }
}