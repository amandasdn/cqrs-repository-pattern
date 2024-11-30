using BookCatalog.Domain.Interfaces;
using BookCatalog.Infra.Repositories;

namespace BookCatalog.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
