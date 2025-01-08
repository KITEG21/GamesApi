using System.Text;
using gamesApi.Data;
using gamesApi.Helpers;
using gamesApi.Interfaces;
using gamesApi.Models;
using gamesApi.Repositories;
using gamesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Adds a method repository(GameRepository)
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x=>{
    x.Password.RequireDigit = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireLowercase = true;
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<AppDBContext>();


builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme =
        x.DefaultScheme =
        x.DefaultForbidScheme =
        x.DefaultSignInScheme =
        x.DefaultSignOutScheme =
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {   
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthSettings.PrivateKey)),
        };
    });

builder.Services.AddDbContext<AppDBContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("Default Connection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

