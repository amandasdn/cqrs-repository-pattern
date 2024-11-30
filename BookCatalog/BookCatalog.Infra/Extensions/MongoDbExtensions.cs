using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalog.Infra.Extensions
{
    public static class MongoDbExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbContext>(provider =>
            {
                var connectionString = configuration.GetConnectionString("MongoDbSettings");
                var databaseName = configuration["MongoDbSettings:DatabaseName"];
                return new MongoDbContext(connectionString, databaseName);
            });
        }
    }
}
