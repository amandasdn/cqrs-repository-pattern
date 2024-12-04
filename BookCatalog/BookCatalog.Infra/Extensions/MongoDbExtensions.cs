using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BookCatalog.Infra.Extensions
{
    public static class MongoDbServiceExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"]
                ?? throw new ArgumentNullException(nameof(configuration), "MongoDbSettings:ConnectionString is missing.");

            var databaseName = configuration["MongoDbSettings:DatabaseName"]
                ?? throw new ArgumentNullException(nameof(configuration), "MongoDbSettings:DatabaseName is missing.");

            services.AddSingleton(_ => new MongoDbContext(connectionString, databaseName));

            BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));
        }
    }

}
