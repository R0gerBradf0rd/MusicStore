using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MusicStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            services.AddValidators();

            services.AddMediatR( cfg =>
                cfg.RegisterServicesFromAssembly( Assembly.GetExecutingAssembly() ) );

            return services;
        }
    }
}
