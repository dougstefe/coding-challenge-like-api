using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Api.Services.Interfaces
{
    public interface IApplicationService{
        Task<ApplicationResponseViewModel> InsertAsync(ApplicationRequestViewModel applicationViewModel);
        Task<AuthenticationResponseViewModel> AuthenticationAsync(AuthenticationRequestViewModel authenticationRequestViewModel);
    }
}