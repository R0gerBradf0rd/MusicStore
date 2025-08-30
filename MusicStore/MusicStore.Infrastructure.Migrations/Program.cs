using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MusicStore.Infrastructure.Contexts;

namespace MusicStore.Infrastructure.Migrations
{
    internal class Program
    {
        public static void Main( string[] args )
        {
            IHost host = Host.CreateDefaultBuilder( args )
                .Build();

            var contextFactory = new DbContextFactory();
            AppDbContext context = contextFactory.CreateDbContext( new string[] { } );
            context.Database.Migrate();

            string[] appliedMigrations = context.Database.GetAppliedMigrations().ToArray();
            Console.WriteLine( String.Join( "\n", appliedMigrations ) );

            host.Start();
            host.StopAsync( TimeSpan.Zero );

            Console.ReadKey();
        }
    }
}
