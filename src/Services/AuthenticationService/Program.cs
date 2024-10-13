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

            // �������� ������������ JWT
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            // ��������� ��������������
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

            // ���������� ������ �����
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CrazyTelegramDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)));
                });

            var app = builder.Build();

            // ��������� Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // �������� �������������� � �����������
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // �������� ����������� CrazyTelegramDbContext ����� ��������� ���� �������� | ������ ����� ��������
            var context = new CrazyTelegramDbContext(
                new DbContextOptionsBuilder<CrazyTelegramDbContext>()
                .UseNpgsql(configuration.GetConnectionString(nameof(CrazyTelegramDbContext)))
                .Options);

            app.Run();
        }
    }
}
