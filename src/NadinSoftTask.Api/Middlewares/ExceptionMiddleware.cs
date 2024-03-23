using System.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using NadinSoftTask.Core.Exceptions;

namespace NadinSoftTask.Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        
        catch (ItemNotFoundException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"The item of the type <{ex.ItemType}> with the id {ex.ItemId} could not be found.",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (UserNotFoundException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"User not found",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (UnauthorizedAccessException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"Unauthorized",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (InvalidOperationException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"User not found",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (DuplicateNameException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"Duplicate Value in the database",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"Invalid input",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }

        catch (Exception ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = "",
                Title = $"Unexpected error",
                Type = "Error"
            };

            var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
    }
}
