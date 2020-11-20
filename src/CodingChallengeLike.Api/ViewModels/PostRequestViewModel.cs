using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class PostRequestViewModel{
        /// <summary>
        /// Post ID
        /// </summary>
        [Required(ErrorMessage = "Field 'Id' is required.")]
        public string Id { get; set; }
        /// <summary>
        /// User of the interaction
        /// </summary>
        [Required(ErrorMessage = "Field 'User' is required.")]
        public UserRequestViewModel User { get; set; }
        /// <summary>
        /// Post title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// if the user liked
        /// </summary>
        [Required(ErrorMessage = "Field 'Liked' is required.")]
        public bool Liked { get; set; }
    }
}