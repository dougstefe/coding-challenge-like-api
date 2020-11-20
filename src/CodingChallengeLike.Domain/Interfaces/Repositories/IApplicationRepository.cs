using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengLike.Domain.Interfaces.Repositories
{
    public interface IApplicationRepository{
        Task<int> InsertAsync(ApplicationInsertDapper application);
    }
}
