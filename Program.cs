using gamesApi.Data;
using gamesApi.Interfaces;
using gamesApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IGameRepository, GameRepository>();
  
builder.Services.AddDbContext<AppDBContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("Default Connection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

