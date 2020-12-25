using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PongUpgraded.Application.Command;
using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Mover;
using PongUpgraded.Application.Views;

namespace PongUpgraded
{
    public static class Program
    {
        public static async Task Main()
        {
            await CreateHostBuilder().Build().RunAsync();
        }
        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddScoped<IInvoker, Invoker>();
                    services.AddScoped<IView, View>();
                    services.AddScoped<IMover, Mover>();
                    services.AddScoped<IMovingLogic, MovingLogic>();
                    services.AddSingleton<IHostedService, GamePresenter>();
                    
                });
    }
}