using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Core.Models;
using Mapster;

namespace CrazyTelegram.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRopository;
        private readonly IJWTProvider _JWTProvider;

        public UserService(IUserRepository userRepository, IJWTProvider JWTProvider)
        {
            _userRopository = userRepository;
            _JWTProvider = JWTProvider;
        }

        public async Task<UserDTO> AddUser(User userDTO)
        {
                if(userDTO.Login == null)
                {
                    return null;
                }

                var foundUser = await _userRopository.GetUserByLogin(userDTO.Login);

                if (foundUser != null)
                {
                    return null;
                    //throw new HttpResponseException(HttpStatusCode.Conflict, $"Пользователь с логином {userDTO.Login} уже зарегистрирован.");
                }

                var user = await _userRopository.Create( userDTO.Adapt<User>());

                return user.Adapt<UserDTO>();
        }

        public async Task<TokenDTO> Login(User user)
        {
            var foundUser = await _userRopository.GetUserByLogin(user.Login);

            if (foundUser == null)
            {
                throw new Exception("Invalid login or password.");
            }

            if (user.Password != foundUser.Password) // Здесь сравниваем открытые пароли
            {
                throw new Exception("Invalid login or password.");
            }

            return new TokenDTO() 
            { 
                Token = _JWTProvider.GenerateToken(foundUser) 
            };
        }
    }
}
