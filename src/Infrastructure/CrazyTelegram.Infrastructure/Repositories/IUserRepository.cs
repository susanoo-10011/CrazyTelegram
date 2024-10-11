using CrazyTelegram.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUserById(string id);
        
    }
}
