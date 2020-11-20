using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallengeLike.Api.ViewModels
{
    public class AuthenticationResponseViewModel{
        /// <summary>
        /// Generated access code
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Type of token
        /// </summary>
        public string TokenType { get; set; }
        /// <summary>
        /// Time of expiration
        /// </summary>
        public int ExpirationIn { get; set; }
    }
}