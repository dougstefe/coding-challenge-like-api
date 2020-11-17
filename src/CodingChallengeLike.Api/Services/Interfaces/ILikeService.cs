using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;

namespace CodingChallengLike.Api.Services.Interfaces
{
    public interface ILikeService{
        Task<PostResponseViewModel> InsertAsync(PostRequestViewModel postViewModel);
        Task UpdateAsync(string userId, string postId, bool liked);
        Task DeleteAsync(string userId, string postId);
    }
}