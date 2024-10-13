using CrazyTelegram.Application.DTO;

namespace CrazyTelegram.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> AddUser(UserDTO userDTO);
    }
}
