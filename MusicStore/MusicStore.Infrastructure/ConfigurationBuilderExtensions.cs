using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace MusicStore.Infrastructure
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddApplicationSettings( this IConfigurationBuilder config )
        {
            config
                .SetBasePath( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ) )
                .AddJsonFile( "appsettings.json", optional: true );

            return config;
        }
    }
}
