using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Application.Services;
using CrazyTelegram.Infrastructure;
using CrazyTelegram.Infrastructure.Data;
using CrazyTelegram.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CrazyTelegram.AuthenticationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Этот метод вызывается один раз при запуске приложения
        public void ConfigureServices(IServiceCollection services)
        {
            // Настройка Dependency Injection
            services.AddControllers();

            // Добавление Swagger (опционально, но рекомендуется для документации API)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            // Регистрация сервисов
            services.AddScoped<IUserService, UserService>(); // Scoped Для зависимостей, которые могут измениться между запросами
            services.AddScoped<IJWTProvider, JwtProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Настройка DbContext
            services.AddDbContext<CrazyTelegramDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString(nameof(CrazyTelegramDbContext))));

            services.AddProblemDetails();

            // Другие настройки DI...
        }

        // Этот метод вызывается после ConfigureServices
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Настройка middleware'ов
            app.UseRouting();

            // Добавление обработчика ошибок
            app.UseExceptionHandler("/Error");

            // Добавление логирования
            //app.UseLogging();

            // Добавление CORS (если необходимо)
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Добавление Swagger UI (если включено)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
            }

            // Настройка маршрутизации
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
