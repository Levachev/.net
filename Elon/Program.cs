using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, MyFirstRedStrategy>();

builder.Services.AddMassTransit(registrConfigurator =>
{
    registrConfigurator.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host("localhost", "/", hostConfigurator =>
        {
            hostConfigurator.Username("guest");
            hostConfigurator.Password("guest");
        });

        cfg.ReceiveEndpoint("elonQueue", ep =>
        {
            ep.Consumer<ElonConsumer>();
        });
        cfg.ReceiveEndpoint("markQueue", ep =>
        {
            ep.Consumer<ElonConsumerMarkPick>();
        });
    });
});

var app = builder.Build();

app.MapControllers();

app.Run();
