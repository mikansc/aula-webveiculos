using Microsoft.EntityFrameworkCore;
using WebVeiculos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurando connection string e banco de dados
// Este serviço estará disponível para todos os controllers
// através do parâmetro [FromServices] WebVeiculosContext context
// ou em seu construtor.
builder.Services.AddDbContext<WebVeiculosContext>(options => options.UseSqlServer("Server=localhost,1433;Database=webveiculos;User ID=sa;Password=@m1chael1234;TrustServerCertificate=true;"));

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
