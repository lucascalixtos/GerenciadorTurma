using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Infra;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Infra.CrossCutting.Middleware;
using GerenciadorTurma.Infra.Data;
using GerenciadorTurma.Infra.Data.Repositories;
using GerenciadorTurma.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IAlunoService, AlunoService>();

builder.Services.AddTransient<ITurmaRepository, TurmaRepository>();
builder.Services.AddTransient<ITurmaService, TurmaService>();

builder.Services.AddTransient<IAlunoTurmaRepository, AlunoTurmaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GerarErrosMiddleware));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
