using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Filters.CustomAttributes
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute():base(typeof(ApiKeyAuthFilter))
        {}
    }
}
