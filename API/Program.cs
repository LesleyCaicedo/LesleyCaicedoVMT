using BusinessLayer.Services;
using DataLayer;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();

builder.Services.AddDbContext<LesleyCaicedoVmtContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );

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
