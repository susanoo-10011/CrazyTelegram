using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;
using Mapster;

namespace CrazyTelegram.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRopository;

        public UserService(IUserRepository userRepository) 
        {
            _userRopository = userRepository;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            try
            {
                if(userDTO.Login == null)
                {
                    return null;
                }

                var foundUser = await _userRopository.GetUserByLogin(userDTO.Login);

                if (foundUser != null)
                {
                    throw new Exception("Такой пользователь уже существует");
                }

                var user = await _userRopository.Create(userDTO);

                return user.Adapt<UserDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
