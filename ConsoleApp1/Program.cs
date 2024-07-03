// See https://aka.ms/new-console-template for more information
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
                
                services.AddHostedService<Simulator>(serviceProvider =>
                new Simulator(
                    1000000,
                    serviceProvider.GetRequiredService<Shuffler>(),
                    serviceProvider.GetRequiredService<Derby>()
                    ));

                services.AddTransient<Shuffler>();

                services.AddScoped<Derby>(serviceProvider =>
                new Derby(
                    new Person(StrategyFactory.createForName("firstRed")),
                    new Person(StrategyFactory.createForName("random"))
                    ));
            });
    }
}
