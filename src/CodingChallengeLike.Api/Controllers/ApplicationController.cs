using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace CodingChallengeLike.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/v1/application")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Register an application
        /// </summary>
        /// <remarks>
        /// Register an application
        /// </remarks>
        /// <param name="applicationRequestViewModel">
        /// Application details
        /// </param>
        /// <returns>
        /// Application registered
        /// </returns>
        /// <response code="201">Interaction registered</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("201", typeof(ApplicationResponseViewModel))]
        [SwaggerResponse("400", typeof(ProblemDetails))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ApplicationResponseViewModel>> PostAsync(ApplicationRequestViewModel applicationRequestViewModel)
        {
            return new ObjectResult(await _applicationService.InsertAsync(applicationRequestViewModel)){
                    StatusCode = StatusCodes.Status201Created
                };
        }
        
        /// <summary>
        /// Authenticate an application
        /// </summary>
        /// <remarks>
        /// Authenticate an application
        /// </remarks>
        /// <param name="authenticationRequestViewModel">
        /// Authenticate details
        /// </param>
        /// <returns>
        /// Successfully authenticated
        /// </returns>
        /// <response code="200">Successfully authenticated</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("200", typeof(AuthenticationResponseViewModel))]
        [SwaggerResponse("400", typeof(ProblemDetails))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseViewModel>> PostAsync(AuthenticationRequestViewModel authenticationRequestViewModel)
        {
            return Ok(await _applicationService.AuthenticationAsync(authenticationRequestViewModel));
        }

    }
}