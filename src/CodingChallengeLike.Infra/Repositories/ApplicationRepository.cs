using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Infra.Context;
using CodingChallengeLike.Domain.Interfaces.Repositories;
using Dapper;

namespace CodingChallengeLike.Infra.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DapperContext _dapperContext;

        public ApplicationRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        
        public async Task<int> InsertAsync(ApplicationInsertDapper application){
            string sqlInsert = @"INSERT INTO
                [ChalengeLike].[Application]
                (
                    Id,
                    Secret,
                    Domains
                )
                VALUES
                (
                    @Id,
                    @Secret,
                    @Domains
                );";
            var result = await _dapperContext.DapperConnection.ExecuteAsync(sqlInsert, application);
            return result;
        }
        public async Task<ApplicationDapper> SelectAsync(string Id){
            var sqlSelect = @"SELECT
                    Id,
                    Secret,
                    Domains
                FROM
                    [ChalengeLike].[Application]
                WHERE 
                    Id=@Id";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<ApplicationDapper>(sqlSelect, new { Id });
        }
    }
}