using Authenticate_Key_Middleware.Services;
using Authenticate_Key_Middleware.Config;
using System.Net;

namespace Authenticate_Key_Middleware.Middlewares
{
    public class ApiKeyMiddleware(RequestDelegate next, IApiKeyValidation apiKeyValidation)
    {
        private readonly RequestDelegate _next = next;
        private readonly IApiKeyValidation _apiKeyValidation = apiKeyValidation;

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Headers[Constant.ApiKeyHeaderName]))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            string? userApiKey = context.Request.Headers[Constant.ApiKeyHeaderName];
            if (!_apiKeyValidation.IsValidApiKey(userApiKey!))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            await _next(context);
        }
    }
}
