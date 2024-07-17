using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, RandomStrategy>();


builder.Services.AddMassTransit(registrConfigurator =>
{
    registrConfigurator.UsingRabbitMq((_, cfg) =>
    {
        cfg.Host("localhost", "/", hostConfigurator =>
        {
            hostConfigurator.Username("guest");
            hostConfigurator.Password("guest");
        });

        cfg.ReceiveEndpoint("markQueue", ep =>
        {
            ep.Consumer<MarkConsumer>();
            ep.Consumer<MarkConsumerElonPick>();
        });
    });
});

var app = builder.Build();

app.MapControllers();

app.Run();
