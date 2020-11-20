using System.Threading.Tasks;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Infra.Context;
using CodingChallengLike.Domain.Interfaces.Repositories;
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
        
        public async Task<int> InsertAsync(ApplicationInsertDapper post){
            string sqlInsert = @"INSERT INTO
                [ChalengeLike].[Post]
                (
                    Id,
                    ApplicationId,
                    UserId,
                    CreatedDate,
                    Title,
                    Liked
                )
                VALUES
                (
                    @Id,
                    @ApplicationId,
                    @UserId,
                    @CreatedDate,
                    @Title,
                    @Liked
                );";
            var result = await _dapperContext.DapperConnection.ExecuteAsync(sqlInsert, post);
            return result;
        }
        public async Task<int> UpdateAsync(string applicationId, string userId, string postId, bool liked){
            string sqlUpdate = @"UPDATE [ChalengeLike].[Post]
                SET
                    Liked = @Liked
                WHERE
                    Id = @Id,
                    ApplicationId = @ApplicationId,
                    UserId = @UserId;";
            var result = await _dapperContext.DapperConnection.ExecuteAsync(sqlUpdate, new {
                Liked = liked,
                Id = postId,
                ApplicationId = applicationId,
                UserId = userId
            });
            return result;
        }
        public async Task<int> DeleteAsync(string applicationId, string userId, string postId){
            string sqlDelete = @"DELETE
                FROM
                    [ChalengeLike].[Post]
                WHERE
                    Id = @Id,
                    ApplicationId = @ApplicationId,
                    UserId = @UserId;";
            var result = await _dapperContext.DapperConnection.ExecuteAsync(sqlDelete, new {
                Id = postId,
                ApplicationId = applicationId,
                UserId = userId
            });
            return result;
        }
        public async Task<PostDapper> GetAsync(string applicationId, string userId, string postId){
            var sqlSelect = @"SELECT
                    Id,
                    CreatedDate,
                    Title,
                    Liked
                FROM
                    [ChalengeLike].[Post]
                WHERE 
                    Id=@Id AND ApplicationId=@ApplicationId AND UserId=@UserId";
            return await _dapperContext.DapperConnection.QueryFirstOrDefaultAsync<PostDapper>(sqlSelect, new {
                Id = postId,
                ApplicationId = applicationId,
                UserId = userId
            });
        }
    }
}