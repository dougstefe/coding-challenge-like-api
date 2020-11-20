using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models.Services;

namespace CodingChallengeLike.Domain.Interfaces.Services
{
    public interface ISsoService
    {
        Task<object> RegisterClient(RegisterClientRequest client);
        Task<object> ConnectToken(AuthenticationRequest client);
    }
}