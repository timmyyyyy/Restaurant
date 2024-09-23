using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.API.Infrastructure;
using Orders.API.Infrastructure.Extensions;
using Orders.Domain.StateMachines;
using System.Reflection;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;
using Orders.Application;
using Orders.Infrastructure;
using Restaurant.Common.InfrastructureBuildingBlocks.Telemetry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = new Assembly[] { typeof(ApplicationMarker).Assembly, typeof(InfrastructureMarker).Assembly, Assembly.GetExecutingAssembly() };
builder.Services.AddAutomaticDependencyRegistration(assemblies);

builder.AddMassTransitConfiguration();

builder.AddDbConfiguration();

builder.Services.AddOpenTelemetry("Orders");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationMarker>());

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

app.UseOpenTelemetry();

app.Run();
