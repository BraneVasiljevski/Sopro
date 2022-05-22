using Microsoft.EntityFrameworkCore;
using SOPRO_TEST_API.Data;
using SOPRO_TEST_API.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<IPersonRepo, PersonRepo>();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("MemoryDataBase"));


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
