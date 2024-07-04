// See https://aka.ms/new-console-template for more information
using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

class Application  {
    /*static void Main(){
        Simulator simulator = new Simulator(1000000);
        int succesCounter = simulator.simulate("firstRed", "random");
        
    }*/
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }


    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContextFactory<Context>(options => options.UseSqlite($"Data Source=decks.db"));
                services.AddHostedService<Simulator>(serviceProvider =>
                new Simulator(
                    1000000,
                    serviceProvider.GetRequiredService<Derby>(),
                    serviceProvider.GetRequiredService<IRepo>()
                    ));
                
                services.AddTransient<Shuffler>();

                services.AddScoped<IRepo, Repo>();

                services.AddScoped<Derby>(serviceProvider =>
                new Derby(
                    serviceProvider.GetRequiredService<Shuffler>(),
                    new Person(StrategyFactory.createForName("firstRed")),
                    new Person(StrategyFactory.createForName("random"))
                    ));
            });
    }
}
