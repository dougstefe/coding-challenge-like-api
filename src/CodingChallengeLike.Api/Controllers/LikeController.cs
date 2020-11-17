using System.Threading.Tasks;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengLike.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<PostResponseViewModel>> PostAsync(PostRequestViewModel postRequestViewModel)
        {
            return Created(nameof(GetAsync), await _likeService.InsertAsync(postRequestViewModel));
        }

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

        [HttpPut("user/{userId}/post/{postId}/liked")]
        public async Task<ActionResult<PostResponseViewModel>> UpdateAsync([FromRoute]string userId, [FromRoute]string postId, PostLikedRequestViewModel postLikedRequestViewModel)
        {
            await _likeService.UpdateAsync(userId, postId, postLikedRequestViewModel);
            return NoContent();
        }

        [HttpDelete("user/{userId}/post/{postId}")]
        public async Task<ActionResult<PostResponseViewModel>> DeleteAsync([FromRoute]string userId, [FromRoute]string postId)
        {
            await _likeService.DeleteAsync(userId, postId);
            return NoContent();
        }
    }
}