using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
builder.Services.AddDbContext<FilmeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// GetConnectionString é um método que retorna a string de conexão com o banco de dados
// AddDbContext é um método que adiciona um contexto de banco de dados ao contêiner de serviços com um escopo de vida de serviço
// UseMySql é um método que adiciona um provedor de banco de dados MySQL ao Entity Framework Core
// ServerVersion.AutoDetect é um método que detecta a versão do servidor de banco de dados

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // adiciona o AutoMapper em todo o contexto da aplicação, faz o mapeamento automatico de um Dto para um Model e vice-versa


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
