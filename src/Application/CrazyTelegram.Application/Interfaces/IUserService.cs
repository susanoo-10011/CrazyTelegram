using CrazyTelegram.Application.DTO;
using CrazyTelegram.Core.Models;

namespace CrazyTelegram.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> AddUser(User user);

        public Task<TokenDTO> Login(User userLogin);
    }
}
