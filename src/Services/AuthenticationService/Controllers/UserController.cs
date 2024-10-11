

using CrazyTelegram.AuthenticationService.Models;
using CrazyTelegram.DataAccess.Postgres;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrazyTelegram.AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//спроси у чат гпт
    public class UserController
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
                var foundUser = await _dbContext.Users.AnyAsync(u => u.Login == user.Login);
                if(foundUser != null)
                {
                    return null;
                }
                return null;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
