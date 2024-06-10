using HR.LeaveManagement.API.Interface;
using Microsoft.AspNetCore.Authorization;

namespace HR.LeaveManagement.API.Policy.Handler
{
    public class ApiKeyHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IApiKeyValidation _apiKeyValidation;

        public ApiKeyHandler(IHttpContextAccessor httpContextAccessor, IApiKeyValidation apiKeyValidation)
        {
            _contextAccessor = httpContextAccessor;
            _apiKeyValidation = apiKeyValidation;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
           string apiKey = _contextAccessor?.HttpContext?.Request.Headers[Constants.Constants.ApiKeyHeaderName].ToString();
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if(!_apiKeyValidation.IsValidApiKey(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
