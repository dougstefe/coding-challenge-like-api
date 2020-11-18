using System.IO;
using System.Text;
using System.Threading.Tasks;
using CodingChallengeLike.Api.Settings;
using CodingChallengeLike.Domain.Interfaces.Identity;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace CodingChallengeLike.Api.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationInsightsSettings _applicationInsights;
        private readonly IWebHostEnvironment _environment;

        public LogMiddleware(RequestDelegate next, IOptions<ApplicationInsightsSettings> options, IWebHostEnvironment environment)
        {
            _next = next;
            _applicationInsights = options.Value;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context, IIdentityService identityService)
        {
            var method = context.Request.Method;
            var telemetry = new TelemetryClient(new TelemetryConfiguration(_applicationInsights.InstrumentationKey));

            telemetry.TrackTrace(new TraceTelemetry(identityService.GetScope(), SeverityLevel.Information));
            
            if ((HttpMethods.IsPost(method) || HttpMethods.IsPut(method) || HttpMethods.IsPatch(method)))
            {
                var body = await FormatRequestBody(context.Request);

                telemetry.TrackTrace(new TraceTelemetry(body, SeverityLevel.Information));
            }

            await _next(context);
        }

        private async Task<string> FormatRequestBody(HttpRequest request)
        {
            var body = string.Empty;

            request.EnableBuffering(bufferThreshold: 1024 * 45, bufferLimit: 1024 * 100);

            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                body = await reader.ReadToEndAsync();
            }

            request.Body.Position = 0;

            return body;
        }


    }
}