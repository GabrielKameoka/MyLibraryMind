using Microsoft.EntityFrameworkCore;
using MyLibraryMind.InfraStructure.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Carrega o .env apenas em desenvolvimento
if (builder.Environment.IsDevelopment())
{
    Env.Load();
}

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();