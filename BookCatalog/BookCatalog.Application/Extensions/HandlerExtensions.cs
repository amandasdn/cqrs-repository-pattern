using BookCatalog.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Application.Extensions
{
    public static class HandlerExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertBookCommand>());

            services.AddTransient<IPipelineBehavior<InsertBookCommand, Guid>, InsertBookCommandValidateBehavior>();

            return services;
        }
    }
}
