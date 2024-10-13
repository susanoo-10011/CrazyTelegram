using CrazyTelegram.AuthenticationService.Models;
using CrazyTelegram.Core.Models;
using CrazyTelegram.DataAccess.Postgres;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
