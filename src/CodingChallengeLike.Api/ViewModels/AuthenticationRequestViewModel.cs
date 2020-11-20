using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class AuthenticationRequestViewModel{
        /// <summary>
        /// Track code to authentication
        /// </summary>
        [Required(ErrorMessage = "Field 'TrackCode' is required.")]
        public string TrackCode { get; set; }
    }
}