using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengLike.Domain.Interfaces.Repositories
{
    public interface IUserRepository{
        Task<int> InsertAsync(UserInsertDapper user);
    }
}