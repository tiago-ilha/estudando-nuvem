using estudandoNuvem.WebApi.Contextos.ControleDeAcesso;
using estudandoNuvem.WebApi.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>(options => options.UseInMemoryDatabase("Database"));

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

using (var scope = app.Services.CreateScope())
{
	var contexto = scope.ServiceProvider.GetRequiredService<Contexto>();

	contexto.Usuarios.Add(Usuario.Criar("admin", "123", "123"));
	contexto.SaveChanges();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
