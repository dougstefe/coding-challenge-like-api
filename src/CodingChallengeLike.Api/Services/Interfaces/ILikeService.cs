using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengLike.Api.Services.Interfaces
{
    public interface ILikeService{
        Task<PostResponseViewModel> InsertAsync(PostRequestViewModel postViewModel);
        Task<PostResponseViewModel> GetAsync(string userId, string postId);
        Task UpdateAsync(string userId, string postId, PostLikedRequestViewModel postLikedRequestViewModel);
        Task DeleteAsync(string userId, string postId);
    }
}