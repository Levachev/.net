// See https://aka.ms/new-console-template for more information
using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gods;
using System;
using MassTransit;

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
                services.AddMassTransit(x =>
                {
                    x.UsingRabbitMq((ctx, cfg) =>
                    {
                        cfg.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                        cfg.ConfigureEndpoints(ctx);
                    });
                });
                services.AddDbContextFactory<Context>(options => options.UseSqlite($"Data Source=decks.db"));
                services.AddHostedService<Simulator>(serviceProvider =>
                new Simulator(
                    1000000,
                    serviceProvider.GetRequiredService<Derby>(),
                    serviceProvider.GetRequiredService<IRepo>(),
                    serviceProvider.GetRequiredService<GodRabbit>()
                    ));

                services.AddTransient<Shuffler>();
                /*services.AddTransient<God>(serviceProvider =>
                new God(serviceProvider.GetRequiredService<Shuffler>()));*/
                services.AddTransient<GodRabbit>();
                services.AddScoped<IRepo, Repo>();
                services.AddScoped<Derby>(serviceProvider =>
                new Derby(
                    serviceProvider.GetRequiredService<Shuffler>(),
                    new Player(StrategyFactory.createForName("firstRed")),
                    new Player(StrategyFactory.createForName("random"))
                 ));
                
            });
    }
}
