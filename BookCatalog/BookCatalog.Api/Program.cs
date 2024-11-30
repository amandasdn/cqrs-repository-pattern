using BookCatalog.Api.Extensions;
using BookCatalog.Application.Extensions;
using BookCatalog.Infra.Extensions;

namespace BookCatalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Extensions
            builder.Services.AddMongoDb(builder.Configuration);
            builder.Services.ConfigureServices();
            builder.Services.AddHandlers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
