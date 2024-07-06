var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, RandomStrategy>();

var app = builder.Build();

app.MapControllers();

app.Run();
