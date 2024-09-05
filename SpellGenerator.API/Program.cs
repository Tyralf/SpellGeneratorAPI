using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Data.Repositories;
using Newtonsoft.Json;
using SpellGenerator.API.Middlewares.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto; // Ajoute les types pour sérialiser correctement les interfaces et classes dérivées
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // Pour un affichage plus lisible
    });

builder.Services.AddScoped<SpellRepository>();
builder.Services.AddScoped<SpellConverter>();
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
