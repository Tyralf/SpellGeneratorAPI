using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Data.Repositories;
using Newtonsoft.Json;
using SpellGenerator.API.Middlewares.ErrorHandling;
using SpellGenerator.Data;
using Microsoft.EntityFrameworkCore;
using SpellGenerator.API.DTOs.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Accéder à la chaîne de connexion dans appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Ajouter le DbContext pour utiliser SQLite
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto; // Ajoute les types pour sérialiser correctement les interfaces et classes dérivées
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // Pour un affichage plus lisible
    });

builder.Services.AddScoped<SpellRepository>();
builder.Services.AddScoped<MagicRepository>();

builder.Services.AddScoped<SpellConverter>();
builder.Services.AddScoped<MagicConverter>();
builder.Services.AddAutoMapper(typeof(MagicProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

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
