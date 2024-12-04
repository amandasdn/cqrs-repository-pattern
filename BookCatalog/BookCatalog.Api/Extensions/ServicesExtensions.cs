using BookCatalog.Domain.Interfaces;
using BookCatalog.Infra.Repositories;
using FluentValidation;
using BookCatalog.Application.Commands;
using BookCatalog.Application.Validators;

namespace BookCatalog.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void AddFluentValidationAndBehaviors(this IServiceCollection services)
        {
            services.AddScoped<IValidator<InsertBookCommand>, InsertBookCommandValidator>();
        }
    }
}
