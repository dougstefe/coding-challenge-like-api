using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class UserRequestViewModel{
        [Required(ErrorMessage = "Field 'User.Id' is required.")]
        public string Id {get;set;}
        public string Name {get;set;}
    }
}