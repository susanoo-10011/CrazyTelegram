using CrazyTelegram.AuthenticationService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AuthenticationService
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        /*public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddControllers();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

            // �������� ����������� CrazyTelegramDbContext ����� ��������� ���� �������� | ������ ����� ��������
            var context = new CrazyTelegramDbContext(
                new DbContextOptionsBuilder<CrazyTelegramDbContext>()
                .UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)))
                .Options);

            app.Run();
        }*/
    }
}
