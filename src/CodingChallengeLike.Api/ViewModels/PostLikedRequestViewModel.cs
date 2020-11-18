using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostLikedRequestViewModel{
        [Required(ErrorMessage = "Field 'Liked' is required.")]
        public bool Liked { get; set; }
    }
}