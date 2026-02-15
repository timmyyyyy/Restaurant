using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Common.ApplicationBuildingBlocks;

namespace Restaurant.Common.InfrastructureBuildingBlocks;

public static class ValidationExtensions
{
    public static IServiceCollection AddFluentValidationWithOperationResult(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies);
        
        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add<OperationResultFilter>();
        });
        
        return services;
    }
    
    public static MediatRServiceConfiguration AddValidationBehavior(
        this MediatRServiceConfiguration config)
    {
        config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return config;
    }
}

