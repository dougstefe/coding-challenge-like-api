using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostLikedRequestViewModel{
        /// <summary>
        /// if the user liked
        /// </summary>
        [Required(ErrorMessage = "Field 'Liked' is required.")]
        public bool Liked { get; set; }
    }
}