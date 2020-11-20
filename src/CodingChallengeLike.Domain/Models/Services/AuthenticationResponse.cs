using System.Collections.Generic;

namespace CodingChallengeLike.Domain.Models.Services
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpirationIn { get; set; }
    }
}