using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CrazyTelegram.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Добавьте конфигурацию JWT
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            // Настройка аутентификации
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            // Добавление других служб
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CrazyTelegramDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)));
                });

            var app = builder.Build();

            // Настройка Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Включаем аутентификацию и авторизацию
            app.UseAuthentication();
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
