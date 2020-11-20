using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CodingChallengeLike.Infra.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration){
            _configuration = configuration;
        }
        
        public IDbConnection DapperConnection
        {
            get
            {
                return new SqlConnection(_configuration["ConnectionStrings:ChallengeLikeDB"]);
            }
        }

    }
}