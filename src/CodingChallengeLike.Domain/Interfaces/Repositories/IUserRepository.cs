using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Domain.Interfaces.Repositories
{
    public interface IUserRepository{
        Task<int> InsertAsync(UserInsertDapper user);
    }
}