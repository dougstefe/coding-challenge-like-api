using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengLike.Api.Services.Interfaces
{
    public interface IApplicationService{
        Task<ApplicationResponseViewModel> InsertAsync(ApplicationRequestViewModel applicationViewModel);
    }
}