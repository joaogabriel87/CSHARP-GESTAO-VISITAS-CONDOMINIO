using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Santi.Context;
using Santi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VisitanteContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<VisitanteContext, VisitanteContext>();
builder.Services.AddTransient<VisitantesServices>();
builder.Services.AddControllers();
// Add services to the container.
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


