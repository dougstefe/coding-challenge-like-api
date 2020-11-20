using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeLike.Api.Controllers
{
    public class ApplicationController
    {
        [ApiController]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces("application/json")]
        [Route("api/v1/application")]
        public class ApplicationController : ControllerBase
        {
            
            public ApplicationController(ILikeService likeService)
            {
                _likeService = likeService;
            }
        }
    }
}