﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Core.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public Guid Id { get; set; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }


        public static User Create(Guid id, string userName, string passwordHash, string email)//создание юзера
        {
            return new User(id, userName, passwordHash, email);
        }

    }
}
