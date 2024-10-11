using CrazyTelegram.Core.Models;
using CrazyTelegram.DataAccess.Postgres;
using CrazyTelegram.DataAccess.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrazyTelegramDbContext _dbContext;
        public UserRepository(CrazyTelegramDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddUser(User user)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.UserName = user.UserName;
            userEntity.Email = user.Email;
            userEntity.Login = user.Login;
            userEntity.Password = user.PasswordHash;
            userEntity.CreatedAt = DateTime.UtcNow;
            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
