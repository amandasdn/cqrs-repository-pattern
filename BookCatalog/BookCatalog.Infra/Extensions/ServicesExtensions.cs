using BookCatalog.Domain.Interfaces;
using BookCatalog.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Infra.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
