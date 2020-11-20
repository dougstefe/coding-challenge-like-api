using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengeLike.Api.Services.Interfaces
{
    public interface ILikeService{
        Task<PostResponseViewModel> InsertAsync(PostRequestViewModel postViewModel);
        Task<PostResponseViewModel> GetAsync(string userId, string postId);
        Task<int> UpdateAsync(string userId, string postId, PostLikedRequestViewModel postLikedRequestViewModel);
        Task<int> DeleteAsync(string userId, string postId);
    }
}