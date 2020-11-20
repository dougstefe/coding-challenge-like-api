using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;

namespace CodingChallengeLike.Domain.Interfaces.Repositories
{
    public interface IApplicationRepository{
        Task<int> InsertAsync(ApplicationInsertDapper application);
        Task<ApplicationDapper> SelectAsync(string Id);
    }
}
