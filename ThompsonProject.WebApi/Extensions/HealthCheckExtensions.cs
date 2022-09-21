using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ThompsonProject.WebApi.Extensions
{
    internal static class HealthCheckExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck("Alive", () => HealthCheckResult.Healthy());

            return services;
        }
    }
}
