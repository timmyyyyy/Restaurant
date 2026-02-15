using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Common.ApplicationBuildingBlocks;
using Restaurant.Common.DomainBuildingBlocks;

namespace Restaurant.Common.InfrastructureBuildingBlocks;

public class OperationResultFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is not ObjectResult { Value: IOperationResult operationResult })
        {
            return;
        }

        if (operationResult.State == OperationResultState.Success)
        {
            return;
        }

        var problemDetails = operationResult.Exception switch
        {
            ValidationException ex =>
                GetValidationProblemDetails(ex, StatusCodes.Status400BadRequest, context, operationResult),
            DomainException =>
                GetProblemDetails("Violation of domain rule", StatusCodes.Status409Conflict, context, operationResult),
            NotFoundException =>
                GetProblemDetails("Not Found", StatusCodes.Status404NotFound, context, operationResult),
            _ => GetProblemDetails("Internal Server Error", StatusCodes.Status500InternalServerError, context, operationResult)
        };

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    private ValidationProblemDetails GetValidationProblemDetails(ValidationException ex, int status,
        ActionExecutedContext context, IOperationResult operationResult)
    {
        var validationProblem = new ValidationProblemDetails
        {
            Status = status,
            Title = "One or more validation errors occurred",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Instance = context.HttpContext.Request.Path
        };

        foreach (var error in ex.Errors)
        {
            validationProblem.Errors[error.Key] = error.Value;
        }

        return validationProblem;
    }

    private ProblemDetails GetProblemDetails(string title, int status,
        ActionExecutedContext context, IOperationResult operationResult) =>
            new()
            {
                Status = status,
                Title = title,
                Detail = operationResult.Exception?.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Instance = context.HttpContext.Request.Path
            };
}
