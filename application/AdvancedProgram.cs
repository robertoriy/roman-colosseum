using model.shuffler;
using application.experiments;
using application.player;
using Microsoft.Extensions.DependencyInjection;
using strategies;
using Microsoft.Extensions.Hosting;
using model.generator;

namespace application
{
    public class AdvancedProgram
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ColosseumExperimentWorker>();
                    services.AddScoped<IColosseumSandbox, ColosseumSandbox>();
                    
                    services.AddSingleton<ICardDeckGenerator, CardDeckGenerator>();
                    services.AddSingleton<ICardDeckShuffler, CardDeckShuffler>();
                    services.AddSingleton<ICardPickStrategy, SimpleCardPickStrategy>();
                    
                    services.AddSingleton<IPlayer, Elon>();
                    services.AddSingleton<IPlayer, Mark>();
                });
        }
    }
}