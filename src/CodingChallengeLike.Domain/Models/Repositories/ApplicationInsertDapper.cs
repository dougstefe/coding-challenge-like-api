using System;
using System.Collections.Generic;

namespace CodingChallengeLike.Domain.Models
{
    public class ApplicationInsertDapper{
        public string Id { get; set; }
        public string Secret { get; set; }
        public IEnumerable<string> Domains { get;set; }
    }
}