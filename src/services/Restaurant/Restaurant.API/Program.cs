using System.Reflection;
using Restaurant.API.Infrastructure.Extensions;
using Restaurant.Application;
using Restaurant.Common.InfrastructureBuildingBlocks;
using Restaurant.Infrastructure;
using Restaurant.Common;
using Restaurant.Common.InfrastructureBuildingBlocks.DI;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = new Assembly[] { typeof(ApplicationMarker).Assembly, typeof(InfrastructureMarker).Assembly, Assembly.GetExecutingAssembly(),
    typeof(CommonMarker).Assembly };
builder.Services.AddAutomaticDependencyRegistration(assemblies);

builder.AddDbConfiguration();
builder.AddMassTransitConfiguration();

builder.Services.AddFluentValidationWithOperationResult(typeof(ApplicationMarker).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<ApplicationMarker>();
    cfg.AddValidationBehavior();
});

var app = builder.Build();

app.MapDefaultEndpoints();

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

