using HR.LeaveManagement.API.Interface;
using System.Net;

namespace HR.LeaveManagement.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApiKeyValidation _apiKeyValidation;
        public ApiKeyMiddleware(RequestDelegate next, IApiKeyValidation apiKeyValidation)
        {
            _next = next;
            _apiKeyValidation = apiKeyValidation;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? userApiKey = context.Request.Headers[Constants.Constants.ApiKeyHeaderName];

            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            if(!_apiKeyValidation.IsValidApiKey(userApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
