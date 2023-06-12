using API.Models;
using Backend.Services.Interfaces;
using Backend.Services.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//Add DbContext

builder.Services.AddDbContext<MASDbContext>(e =>
{
    e.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres");
});

// Add services to the container.
//services.AddScoped<>

builder.Services.AddScoped<ITrainStationService, TrainStationService>();
builder.Services.AddScoped<ITransitService, TransitService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
