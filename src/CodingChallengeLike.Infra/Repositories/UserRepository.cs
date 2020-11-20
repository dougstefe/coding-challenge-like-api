using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Infra.Context;
using CodingChallengLike.Domain.Interfaces.Repositories;
using Dapper;

namespace CodingChallengeLike.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;

        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> InsertAsync(UserInsertDapper user){
            string sqlInsert = @"INSERT INTO
                [ChalengeLike].[User]
                (
                    Id,
                    ApplicationId,
                    Name
                )
                VALUES
                (
                    @Id,
                    @ApplicationId,
                    @Name
                );";
            var result = await _dapperContext.DapperConnection.ExecuteAsync(sqlInsert, user);
            return result;
        }
    }
}