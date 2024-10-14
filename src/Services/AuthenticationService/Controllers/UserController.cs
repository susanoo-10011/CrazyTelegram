using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Core.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CrazyTelegram.AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            var result = await _userService.AddUser(user.Adapt<User>());

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            try
            {
                var token = await _userService.Login(user.Adapt<User>());

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
