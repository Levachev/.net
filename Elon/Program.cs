var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, MyFirstRedStrategy>();

var app = builder.Build();

app.MapControllers();

app.Run();
