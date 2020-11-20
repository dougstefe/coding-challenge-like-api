using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Domain.Interfaces.Repositories
{
    public interface IPostRepository{
        Task<int> InsertAsync(PostInsertDapper post);
        Task<int> UpdateAsync(string applicationId, string userId, string postId, bool liked);
        Task<int> DeleteAsync(string applicationId, string userId, string postId);
        Task<PostDapper> GetAsync(string applicationId, string userId, string postId);
    }
}
