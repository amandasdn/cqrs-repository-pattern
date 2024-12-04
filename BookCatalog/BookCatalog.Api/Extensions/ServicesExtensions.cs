using BookCatalog.Domain.Interfaces;
using BookCatalog.Infra.Repositories;
using FluentValidation;
using BookCatalog.Application.Commands;
using BookCatalog.Application.Validators;
using BookCatalog.Application.Mappings;

namespace BookCatalog.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddAutoMapper(typeof(BookMappingProfile));

            services.AddScoped<IValidator<InsertBookCommand>, InsertBookCommandValidator>();
        }
    }
}
