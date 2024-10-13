using CrazyTelegram.AuthenticationService.Models;
using CrazyTelegram.Core.Models;
using CrazyTelegram.DataAccess.Postgres;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrazyTelegram.AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase // Изменено на наследование от ControllerBase
    {
        private readonly CrazyTelegramDbContext _dbContext;

        public UserController(CrazyTelegramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTO user)
        {
            try
            {
                // Проверяем, существует ли пользователь с таким логином
                var foundUser = await _dbContext.Users.AnyAsync(u => u.Login == user.Login);
                if (foundUser)
                {
                    return Conflict("User with this login already exists.");
                }

                // Создаем нового пользователя типа UserEntity
                var newUser = new UserEntity
                {
                    UserName = user.UserName,
                    Password = user.PasswordHash,
                    Email = user.Email,
                    Login = user.Login
                    //CreatedAt = DateTime.Now
                };

                // Сохраняем пользователя в базе данных
                await _dbContext.Users.AddAsync(newUser);

                // Сохраняем изменения и обрабатываем возможные исключения
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException dbEx)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Database update error: " + dbEx.Message);
                }

                // Возвращаем ответ с кодом 201 и информацией о созданном пользователе
                return CreatedAtAction(nameof(Register), new { id = newUser.Id }, newUser);
            }
            catch (DbUpdateException dbEx)
            {
                var innerExceptionMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : "No inner exception.";
                var errorMessage = $"Database update error: {dbEx.Message}. Inner exception: {innerExceptionMessage}";

                // Логируйте сообщение об ошибке (например, в консоль или файл)
                Console.WriteLine(errorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                // Находим пользователя по логину
                var foundUser = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Login == user.Login);

                // Если пользователь не найден, возвращаем 401 Unauthorized
                if (foundUser == null)
                {
                    return Unauthorized("Invalid login or password.");
                }

                // Сравниваем введенный пароль с паролем из базы данных
                if (user.PasswordHash != foundUser.Password) // Здесь сравниваем открытые пароли
                {
                    return Unauthorized("Invalid login or password.");
                }

                // Генерируем токен
                var token = GenerateJwtToken(foundUser);

                // Возвращаем токен
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        private static string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Login),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim("id", user.Id.ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123")); // Используем тот же ключ, что и в конфигурации
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Время жизни токена
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        [HttpGet("me")]
        /*[Authorize]*/ // Этот метод доступен только для авторизованных пользователей
        public ActionResult<UserDTOAuth> GetCurrentUser()
        {
            // Получаем токен из заголовка Authorization
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token is missing.");
            }

            try
            {
                // Создаем токен обработчик
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    return Unauthorized("Invalid token.");
                }

                // Извлекаем данные из токена
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "id");
                var userLoginClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);

                if (userIdClaim == null || userLoginClaim == null)
                {
                    return Unauthorized("Invalid token claims.");
                }

                // Создаем объект UserDTOAuth для возврата
                var userDtoAuth = new UserDTOAuth
                {
                    PasswordHash = userLoginClaim.Value,
                    Login = userLoginClaim.Value,
                    
                };

                return Ok(userDtoAuth);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while decoding token: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }



}
