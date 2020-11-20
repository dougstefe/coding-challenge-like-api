using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace CodingChallengeLike.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/v1/like")]
    public class LikeController : ControllerBase
    {
        public readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Register an interaction in a post
        /// </summary>
        /// <remarks>
        /// Register an interaction in a post
        /// </remarks>
        /// <param name="postRequestViewModel">
        /// Post details
        /// </param>
        /// <returns>
        /// Interaction registered
        /// </returns>
        /// <response code="201">Interaction registered</response>
        /// <response code="401">Access denied</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("201", typeof(PostResponseViewModel))]
        [SwaggerResponse("401", typeof(string))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpPost]
        public async Task<ActionResult<PostResponseViewModel>> PostAsync(PostRequestViewModel postRequestViewModel)
        {
            var result = await _likeService.InsertAsync(postRequestViewModel);
            return CreatedAtAction(nameof(GetAsync), new {PostId = result.Id, UserId = postRequestViewModel.User.Id}, result);
        }

        /// <summary>
        /// Query interaction data in a post
        /// </summary>
        /// <remarks>
        /// Query interaction data in a post
        /// </remarks>
        /// <param name="userId">
        /// User ID
        /// </param>
        /// <param name="postId">
        /// Post ID
        /// </param>
        /// <returns>
        /// Interaction located
        /// </returns>
        /// <response code="200">Interaction located</response>
        /// <response code="401">Access denied</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("200", typeof(PostResponseViewModel))]
        [SwaggerResponse("401", typeof(string))]
        [SwaggerResponse("404", typeof(ProblemDetails))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpGet("user/{userId}/post/{postId}")]
        public async Task<ActionResult<PostResponseViewModel>> GetAsync([FromRoute]string userId, [FromRoute]string postId)
        {
            var result = await _likeService.GetAsync(userId, postId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        /// <summary>
        /// Updates interaction data on a post
        /// </summary>
        /// <remarks>
        /// Updates interaction data on a post
        /// </remarks>
        /// <param name="userId">
        /// User ID
        /// </param>
        /// <param name="postId">
        /// Post ID
        /// </param>
        /// <param name="postLikedRequestViewModel">
        /// Interation details
        /// </param>
        /// <returns>
        /// Interaction updated
        /// </returns>
        /// <response code="204">Interaction updated</response>
        /// <response code="401">Access denied</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("204", typeof(void))]
        [SwaggerResponse("401", typeof(string))]
        [SwaggerResponse("404", typeof(ProblemDetails))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpPut("user/{userId}/post/{postId}/liked")]
        public async Task<ActionResult> UpdateAsync([FromRoute]string userId, [FromRoute]string postId, PostLikedRequestViewModel postLikedRequestViewModel)
        {
            var result = await _likeService.UpdateAsync(userId, postId, postLikedRequestViewModel);
            if(result < 1){
                return NotFound();
            }
            return NoContent();
        }
        
        /// <summary>
        /// Delete interaction data in a post
        /// </summary>
        /// <remarks>
        /// Delete interaction data in a post
        /// </remarks>
        /// <param name="userId">
        /// User ID
        /// </param>
        /// <param name="postId">
        /// Post ID
        /// </param>
        /// <returns>
        /// Interaction deleted
        /// </returns>
        /// <response code="204">Interaction deleted</response>
        /// <response code="401">Access denied</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse("204", typeof(void))]
        [SwaggerResponse("401", typeof(string))]
        [SwaggerResponse("404", typeof(ProblemDetails))]
        [SwaggerResponse("500", typeof(ProblemDetails))]
        [HttpDelete("user/{userId}/post/{postId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]string userId, [FromRoute]string postId)
        {
            var result = await _likeService.DeleteAsync(userId, postId);
            if(result < 1){
                return NotFound();
            }
            return NoContent();
        }
    }
}