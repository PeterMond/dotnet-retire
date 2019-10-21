using System;
using DotNet.Retire.Runtimes.Core;
using DotNet.Retire.Runtimes.Middleware;

// ReSharper disable once CheckNamespace
// On purpose to avoid cluttering hosts with new package namespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRetireRuntimeHostedService(this IServiceCollection services, Action<RetireRuntimeBackgroundServiceOptions> configurator = null)
        {
            if (configurator == null)
            {
                services.Configure<RetireRuntimeBackgroundServiceOptions>(c => c.CheckInterval = 5000);
            }
            else
            {
                services.Configure(configurator);
            }

            services.AddSingleton<ReportGenerator>();
            return services.AddHostedService<RetireRuntimeBackgroundService>();
        }
    }
}
