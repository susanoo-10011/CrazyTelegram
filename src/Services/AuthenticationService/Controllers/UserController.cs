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

        public UserController(
            IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IResult> Register([FromBody] UserDTO user)
        {
            try
            {
                var result = await _userService.AddUser(user);

                return Results.Ok(result);

            }
            catch (Exception ex) 
            {
                return Results.BadRequest(new
                {
                    Error = "Произошла ошибка при регистрации",
                    Message = ex.Message
                });
            }
        }
    }
}
