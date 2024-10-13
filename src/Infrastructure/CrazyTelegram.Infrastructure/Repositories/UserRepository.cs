using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Core.Models;
using CrazyTelegram.Infrastructure.Data;
using CrazyTelegram.Infrastructure.Data.Entities;

namespace CrazyTelegram.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrazyTelegramDbContext _dbContext;
        public UserRepository(CrazyTelegramDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> Create(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = await _dbContext.Users.FindAsync(login);

            return null;
        }
    }
}
