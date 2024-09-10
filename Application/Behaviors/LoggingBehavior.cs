using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            _logger.LogInformation(
@"Starting request:
{name},
{datetime},
{json}",
typeof(TRequest).Name,
DateTime.Now,
JsonSerializer.Serialize(request, options));

            Stopwatch stopwatch = Stopwatch.StartNew();

            TResponse? response = await next();

            stopwatch.Stop();

            _logger.LogInformation(
@"Completed request:
{name},
{stopwatch}ms,
{response}",
typeof(TRequest).Name,
stopwatch.ElapsedMilliseconds,
JsonSerializer.Serialize(response, options));

            return response;
        }
    }
}
