using Martian_Robots.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Martian_Robots
{
    public static class Container
    {
        public static void addScopes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMainGameService, MainGameService>();
        }
    }
}
