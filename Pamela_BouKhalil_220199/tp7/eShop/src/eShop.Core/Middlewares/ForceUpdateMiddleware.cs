using Ardalis.GuardClauses;
using eShop.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace eShop.Core.Middlewares
{
    internal class ForceUpdateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ForceUpdateMiddleware> _logger;

        public ForceUpdateMiddleware(RequestDelegate next, ILogger<ForceUpdateMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var request = httpContext.Request;
            if (request.Headers.TryGetValue("app-version", out var versionValue))
            {
                try
                {
                    var version = Version.FromString(versionValue);
                    if (version.Major < 2)
                    {
                        _logger.LogInformation("Version {version} no longer supported", version);
                        httpContext.Response.StatusCode = (int)HttpStatusCode.UpgradeRequired;
                        httpContext.Response.ContentType = "application/json";
                        var errorModel = new ErrorModel()
                        {
                            Code = "version_not_supported",
                            Description = "The current version of the app is no longer supported. Please update it and try again"
                        };
                        await httpContext.Response.WriteAsync(errorModel.ToString());
                        return;
                    }
                }
                catch(ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    var errorModel = new ErrorModel()
                    {
                        Code = "bad_version",
                        Description = ex.Message
                    };
                    await httpContext.Response.WriteAsync(errorModel.ToString());
                    return;
                }
            }
            await _next(httpContext);
        }
    }

    internal sealed class Version
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Patch { get; private set; }

        private Version(string version)
        {
            Guard.Against.NullOrWhiteSpace(version, nameof(version), "Version cannot be null or empty");
            var split = version.Split('.');
            if (split.Length != 3)
            {
                throw new ArgumentException("Version malformatted!");
            }
            var chars = split.SelectMany(x => x.ToCharArray()).ToList();
            var isDigits = chars.All(char.IsDigit);
            if (chars.Count != 3 || !isDigits)
            {
                throw new ArgumentException("Version does not contain exactly 3 digits!");
            }
            Major = Convert.ToInt32(split[0]);
            Minor = Convert.ToInt32(split[1]);
            Patch = Convert.ToInt32(split[2]);
        }

        public static Version FromString(string value)
        {
            return new Version(value);
        }
    }

    public static class ForceUpdateMiddlewareExtensions
    {
        public static void UseForceUpdate(this IApplicationBuilder app)
        {
            app.UseMiddleware<ForceUpdateMiddleware>();
        }
    }
}
