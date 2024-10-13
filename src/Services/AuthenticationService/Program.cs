using CrazyTelegram.AuthenticationService;
using CrazyTelegram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CrazyTelegramDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)));
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // вызываем конструктор CrazyTelegramDbContext чтобы применить наши миграции | скорее всего временно
            var context = new CrazyTelegramDbContext(
                new DbContextOptionsBuilder<CrazyTelegramDbContext>()
                .UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)))
                .Options);

            app.Run();
        }
    }
}
