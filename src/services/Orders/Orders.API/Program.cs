using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.API.Infrastructure;
using Orders.API.Infrastructure.Extensions;
using Orders.Domain.StateMachines;
using System.Reflection;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutomaticDependencyRegistration(Assembly.GetExecutingAssembly());

builder.AddMassTransitConfiguration();

builder.AddDbConfiguration();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
