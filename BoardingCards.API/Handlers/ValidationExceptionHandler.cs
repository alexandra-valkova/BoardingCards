using BoardingCards.API.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace BoardingCards.API.Handlers
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validation)
            {
                return false;
            }

            int statusCode = StatusCodes.Status400BadRequest;

            HttpValidationProblemDetails validationProblem = new()
            {
                Detail = "Some boarding cards didn't pass validation, see the errors below.",
                Instance = httpContext.Request.Path,
                Status = statusCode,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Errors = validation.Errors.ToDictionary()
            };

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(validationProblem, cancellationToken);

            return true;
        }
    }
}
