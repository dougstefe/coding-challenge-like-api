using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallengeLike.Api.Extensions;
using CodingChallengeLike.Api.Middlewares;
using CodingChallengeLike.Api.Settings;
using CodingChallengeLike.Api.Swagger;
using CodingChallengeLike.Domain.Interfaces.Identity;
using CodingChallengeLike.Infra.Context;
using CodingChallengeLike.Infra.Identity;
using CodingChallengeLike.Infra.Repositories;
using CodingChallengeLike.Api.Services;
using CodingChallengeLike.Api.Services.Interfaces;
using CodingChallengeLike.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using CodingChallengeLike.Infra.Services;
using CodingChallengeLike.Domain.Interfaces.Services;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Polly;
using CodingChallengeLike.Domain.Interfaces.Notifications;
using CodingChallengeLike.Domain.Notifications;
using CodingChallengeLike.Api.Filters;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using NSwag.Generation.Processors.Security;
using NSwag;

namespace CodingChallengeLike.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(options => {
                    options.Filters.Add<DomainNotificationFilter>();
                    options.EnableEndpointRouting = false;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = Configuration["IdentityServer:Authority"];
                    options.Audience = Configuration["IdentityServer:Audience"];
                });
            
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(x =>
            {
                x.Providers.Add<GzipCompressionProvider>();
            });

            if (PlatformServices.Default.Application.ApplicationName != "testhost")
            {
                var healthCheck = services.AddHealthChecksUI(setupSettings: setup =>
                    {
                        setup.AddHealthCheckEndpoint("liveness", "/health");
                        setup.AddHealthCheckEndpoint("readness", "/ready");
                    }).AddHealthChecks()
                    .AddProcessAllocatedMemoryHealthCheck(500 * 1024 * 1024, "Process Memory", tags: new[] { "self" })
                    .AddPrivateMemoryHealthCheck(1500 * 1024 * 1024, "Private memory", tags: new[] { "self" })
                    .AddIdentityServer(new Uri(Configuration["IdentityServer:Authority"]), "Identity Server", tags: new[] { "services" })
                    .AddApplicationInsightsPublisher();
            }

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                document.Version = "v1";
                document.Title = "Like API";
                document.Description = "API to count likes in posts";
                document.GenerateXmlObjects = true;
                document.SchemaNameGenerator = new CustomSchemaNameGenerator();
            });

            if (WebHostEnvironment.IsProduction())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins(Configuration["Gateway"])
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });
            }

            services.AddAutoMapper(typeof(Startup));
            services.AddHttpContextAccessor();
            services.AddApplicationInsightsTelemetry();

            RegisterServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ApplicationInsightsSettings> options)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else{
                app.UseHsts();
            }

            app.UseCors();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseLogMiddleware();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(options, env).Invoke
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("self"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/ready", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("services"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(opt =>
                {
                    opt.UIPath = "/health-ui";
                });
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.Configure<ApplicationInsightsSettings>(Configuration.GetSection("ApplicationInsights"));

            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            
            services.AddScoped<IDomainNotification, DomainNotification>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<DapperContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddHttpClient<ISsoService, SsoService>((s, c) =>
            {
                c.BaseAddress = new Uri(Configuration["IdentityServer:Authority"]);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.OrResult(response =>
            {
                var status = (int)response.StatusCode;
                return status.Equals(StatusCodes.Status500InternalServerError) || status.Equals(StatusCodes.Status502BadGateway) || status.Equals(StatusCodes.Status503ServiceUnavailable) || status.Equals(StatusCodes.Status504GatewayTimeout);
            }).WaitAndRetryAsync(3, retry =>
                   TimeSpan.FromSeconds(Math.Pow(2, retry)) +
                   TimeSpan.FromMilliseconds(new Random().Next(0, 100))))
              .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(
                   handledEventsAllowedBeforeBreaking: 3,
                   durationOfBreak: TimeSpan.FromSeconds(30)
            ));

        }
    }
}
