using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BookCatalog.Infra.Extensions
{
    public static class MongoDbExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbContext>(provider =>
            {
                var connectionString = configuration["MongoDbSettings:ConnectionString"];
                var databaseName = configuration["MongoDbSettings:DatabaseName"];
                return new MongoDbContext(connectionString, databaseName);
            });

            BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));
        }
    }
}
