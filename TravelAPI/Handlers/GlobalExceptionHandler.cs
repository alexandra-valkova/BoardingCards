using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails = exception switch
            {
                BoardingCardException boardingCardException => new()
                {
                    Title = "Boarding cards exception.",
                    Detail = boardingCardException.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Status = StatusCodes.Status400BadRequest
                },
                _ => new()
                {
                    Title = exception.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Status = StatusCodes.Status500InternalServerError
                }
            };

            problemDetails.Instance = httpContext.Request.Path;
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
