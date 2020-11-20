using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class UserRequestViewModel{
        /// <summary>
        /// User ID
        /// </summary>
        [Required(ErrorMessage = "Field 'User.Id' is required.")]
        public string Id {get;set;}
        /// <summary>
        /// User name
        /// </summary>
        public string Name {get;set;}
    }
}