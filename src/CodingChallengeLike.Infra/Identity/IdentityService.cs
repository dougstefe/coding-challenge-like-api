using System.Linq;
using CodingChallengeLike.Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Http;

namespace CodingChallengeLike.Infra.Identity
{
    public class IdentityService : IIdentityService {
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string GetApplicationId() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("application-id"))?.Value;
        public string GetScope() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("scope"))?.Value;
        
    }
}