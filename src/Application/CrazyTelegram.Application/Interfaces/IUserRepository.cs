using CrazyTelegram.Application.DTO;
using CrazyTelegram.Core.Models;

namespace CrazyTelegram.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Create(UserDTO user);
        public Task<User> GetUserById(string id);
        public Task<User> GetUserByLogin(string login);
    }
}
