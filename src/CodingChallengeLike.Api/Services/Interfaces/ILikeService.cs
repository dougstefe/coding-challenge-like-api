using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengLike.Api.Services.Interfaces
{
    public interface ILikeService{
        Task<LikeResponseViewModel> InsertAsync(LikeRequestViewModel likeRequestViewModel);
        Task UpdateAsync(LikeRequestViewModel likeRequestViewModel);
        Task DeleteAsync(LikeRequestViewModel likeRequestViewModel);
    }
}