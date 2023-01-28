using FreeMovies.API.Models;
using System.Text.Json.Serialization;
// using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using FreeMovies.API.Models.Repositories;
// using Nile.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<FreeMoviesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FreeMoviesDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();  
builder.Services.AddScoped<IActorRepository, ActorRepository>();  
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
