using System.Configuration;
using System.Text.Json.Serialization;
using API.Repositories.Song;
using API.Repositories.Artist.SearchArtist;
using API.Repositories.Artist.AddArtist;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Each API needs to handle its own connectionString since scenerios may arise where Different Databases are involved.
builder.Services.AddScoped<ISearchArtistRepository, SearchArtistRepository>(provider => new SearchArtistRepository("Data source=localhost;DATABASE=MultiTracksDB;Integrated Security=True"));
builder.Services.AddScoped<ISongsRepository, SongsRepository>(provider => new SongsRepository("Data source=localhost;DATABASE=MultiTracksDB;Integrated Security=True"));
builder.Services.AddScoped<IAddArtistRepository, AddArtistRepository>(provider => new AddArtistRepository("Data source=localhost;DATABASE=MultiTracksDB;Integrated Security=True"));

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
