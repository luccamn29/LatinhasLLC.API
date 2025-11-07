using System.Net;
using System.Text.Json;
using FluentValidation;

namespace LatinhasLLC.API.WebUI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, _logger);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode status;
        object response;

        switch (ex)
        {
            case ValidationException validationEx:
                status = HttpStatusCode.BadRequest;
                response = new
                {
                    message = "Erro de validação",
                    statusCode = (int)status,
                    errors = validationEx.Errors.Select(e => new
                    {
                        propertyName = e.PropertyName,
                        errorMessage = e.ErrorMessage
                    })
                };
                break;

            case InvalidOperationException:
                status = HttpStatusCode.BadRequest;
                response = new { message = ex.Message, statusCode = (int)status };
                break;

            case KeyNotFoundException:
                status = HttpStatusCode.NotFound;
                response = new { message = ex.Message, statusCode = (int)status };
                break;

            default:
                status = HttpStatusCode.InternalServerError;
                response = new { message = ex.Message, statusCode = (int)status };
                break;
        }

        logger.LogError(ex, "Erro inesperado: {Message}", ex.Message);

        context.Response.StatusCode = (int)status;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
