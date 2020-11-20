using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class ApplicationRequestViewModel{
        [Required(ErrorMessage = "Field 'Domains' is required.")]
        public IEnumerable<string> Domains { get; set; }
    }
}