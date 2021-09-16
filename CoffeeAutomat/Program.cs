using CoffeeAutomat.Interfaces;
using CoffeeAutomat.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoffeeAutomat
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            ConfigureServices();
            _ = serviceProvider.GetService<IAppService>();

            
        }
        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IAppService, AppService>();
            services.AddSingleton<IAutomatService, AutomatService>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
