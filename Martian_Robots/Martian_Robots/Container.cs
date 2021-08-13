using Martian_Robots.Services;
using Martian_Robots.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Martian_Robots
{
    public static class Container
    {
        public static void addScopes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMainService, MainService>();
            serviceCollection.AddScoped<ISQLiteService, SQLiteService>();
            serviceCollection.AddScoped<IStadisticsService, StadisticsService>();
        }
    }
}