using System.Text.Json.Serialization;
using ApiGestaoFacil.DataContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   { 
       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; 
       x.JsonSerializerOptions.WriteIndented = true;
   });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Busca string de conex�o e adiciona a classe AppDbContext Service do EF
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
