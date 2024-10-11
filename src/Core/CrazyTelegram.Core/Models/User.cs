using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Core.Models
{
    public class User
    {
        private User(int id, string userName, string passwordHash, string email, string login)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            Login = login;
        }

        public int Id { get; set; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

        public string Login { get; set; }


        public static User Create(int id, string userName, string passwordHash, string email, string login)//создание юзера
        {
            return new User(id, userName, passwordHash, email, login);
        }

    }
}
