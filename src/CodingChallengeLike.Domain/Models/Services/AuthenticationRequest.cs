using System.Collections.Generic;

namespace CodingChallengeLike.Domain.Models.Services
{
    public class AuthenticationRequest
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public IEnumerable<string> Scopes { get; set; }
    }
}