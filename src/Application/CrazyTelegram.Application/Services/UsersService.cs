using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;

namespace CrazyTelegram.Application.Services
{
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRopository;

        public UsersService(IUserRepository userRepository) 
        {
            _userRopository = userRepository;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            try
            {
                //UserEntity userEntity = new UserEntity();
                //userEntity.UserName = userDTO.Username;
                //userEntity.Email = userDTO.Email;
                //userEntity.Password = userDTO.Password;
                //userEntity.Login = userDTO.Login;
                //userEntity.CreatedAt = DateTime.UtcNow;

                var foundUser = _userRopository.GetUserByLogin(userEntity.Login);

                if (foundUser != null)
                {
                    throw new Exception("Такой пользователь уже существует");
                }

                var user = _userRopository.Create(userEntity);

                return userDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
