using CodingChallengeLike.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CodingChallengeLike.Api.Extensions
{
    public static class LogExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}