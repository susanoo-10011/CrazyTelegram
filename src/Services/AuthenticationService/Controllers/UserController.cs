using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrazyTelegram.AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserService userService,
            IUserRepository userRepository) 
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTO user)
        {
            try
            {
                var result = await _userService.AddUser(user);

                return new OkObjectResult(result);

            }
            catch (Exception ex) 
            {
                ProblemDetails details = new ProblemDetails();
                details.Title = "Ошибка при регистрации";
                details.Detail = $"Произошла ошибка при регистрации пользователя: {ex.Message}";
                details.Status = 500;

                return null ;
            }
        }
    }
}
