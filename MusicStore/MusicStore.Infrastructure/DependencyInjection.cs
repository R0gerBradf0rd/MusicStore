using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Infrastructure.Contexts;
using MusicStore.Infrastructure.Repositories;
using MusicStore.Infrastructure.UnitsOfWork;

namespace MusicStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddUnitOfWork();
            services.AddRepositories();

            services.AddDbContext<AppDbContext>( options =>
                options.UseNpgsql( configuration.GetConnectionString( "MusicStore.ConnectionString" ) ) );

            return services;
        }
    }
}
