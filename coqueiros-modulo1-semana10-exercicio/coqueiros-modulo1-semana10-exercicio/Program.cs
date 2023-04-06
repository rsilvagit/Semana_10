using Microsoft.EntityFrameworkCore;
using coqueiros_modulo1_semana10_exercicio.Models;
using System.Collections.Specialized;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = "Server=DESKTOP-9HO92VC\\SQLEXPRESS;Database=Mes;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<LocacaoContext>(o => o.UseSqlServer(connectionString));


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
