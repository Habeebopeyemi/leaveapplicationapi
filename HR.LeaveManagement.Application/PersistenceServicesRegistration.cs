using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<HRLeaveManagementDbContext>();

            return services;
        }
    }
}
