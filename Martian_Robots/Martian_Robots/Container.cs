using Martian_Robots.Controllers;
using Martian_Robots.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
