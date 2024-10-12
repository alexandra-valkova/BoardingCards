using System.Reflection;
using BoardingCards.Application.Behaviors;
using BoardingCards.Application.Services;
using BoardingCards.Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BoardingCards.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IBoardingCardService, BoardingCardService>();

            services.AddValidatorsFromAssembly(assembly);

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
    }
}
