using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ProductPortfolio.Configuration;
using System.Threading.Tasks;

namespace ProductPortfolio.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AuthenticationSettings> _authSettings;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<AuthenticationSettings> config)
        {
            _next = next;
            _authSettings = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string apiKey = context.Request.Headers["X-API-KEY"];
            if (!string.IsNullOrEmpty(apiKey))
            {
                if (IsValidApiKey(apiKey))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }
            }
            else
            {
                // no api key specified
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }
        }

        #region Utility Methods

        /// <summary>
        /// Validate an ApiKey
        /// </summary>
        /// <param name="apiKey">Api Key to validate</param>
        /// <returns>True or False</returns>
        bool IsValidApiKey(string apiKey)
        {
            if (_authSettings == null)
                return false;

            if (_authSettings.Value == null)
                return false;

            if (_authSettings.Value.ApiKeys == null)
                return false;

            if (!_authSettings.Value.ApiKeys.Contains(apiKey))
                return false;

            // Valid ApiKey
            return true;
        }

        #endregion
    }
}