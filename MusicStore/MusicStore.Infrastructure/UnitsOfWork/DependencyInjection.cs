using Microsoft.Extensions.DependencyInjection;
using MusicStore.Application.Interfaces.UnitOfWork;

namespace MusicStore.Infrastructure.UnitsOfWork
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork( this IServiceCollection services )
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
