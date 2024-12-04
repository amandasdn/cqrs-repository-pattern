using BookCatalog.Application.Commands;
using BookCatalog.Application.DTOs;
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

            services.AddTransient<IPipelineBehavior<InsertBookCommand, BookDto>, InsertBookCommandValidateBehavior>();

            return services;
        }
    }
}
