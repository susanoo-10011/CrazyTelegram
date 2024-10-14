using CrazyTelegram.Application.DTO;
using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Core.Models;
using CrazyTelegram.Infrastructure.Data;
using CrazyTelegram.Infrastructure.Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CrazyTelegram.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrazyTelegramDbContext _dbContext;

        public UserRepository(CrazyTelegramDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> Create(UserDTO user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user.Adapt<UserEntity>());
                await _dbContext.SaveChangesAsync();

                return user.Adapt<User>();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user.Adapt<User>();
        }
    }
}
