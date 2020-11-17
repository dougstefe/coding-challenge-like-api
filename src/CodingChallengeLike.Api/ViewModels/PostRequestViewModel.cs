using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostRequestViewModel{
        [Required(ErrorMessage = "Field 'Id' is required.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Field 'User' is required.")]
        public UserRequestViewModel User { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Field 'Liked' is required.")]
        public bool Liked { get; set; }
    }
}