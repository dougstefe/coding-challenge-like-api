using System.Collections.Generic;

namespace CodingChallengeLike.Domain.Models
{
    public class ApplicationRequestModel{
        public IEnumerable<string> Domains { get; set; }
    }
}