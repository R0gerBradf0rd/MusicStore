using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Migrations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext( string[] args )
        {
            IConfiguration config = GetConfig();
            string connectionString = config.GetConnectionString( "MusicStore.ConnectionString" );

            var optionalBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionalBuilder.UseNpgsql(
                connectionString: connectionString,
                npgsqlOptionsAction: assembly => assembly.MigrationsAssembly( "MusicStore.Infrastructure.Migrations" ) );

            return new AppDbContext( optionalBuilder.Options );
        }

        private static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddApplicationSettings();

            return builder.Build();
        }
    }

}

