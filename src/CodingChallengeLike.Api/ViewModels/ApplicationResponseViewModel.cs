using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class ApplicationResponseViewModel{
        public string TrackCode { get; set; }
        public IEnumerable<string> Domains { get; set; }
    }
}