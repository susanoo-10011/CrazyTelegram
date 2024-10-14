using CrazyTelegram.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Application.Interfaces
{
    public interface IJWTProvider
    {
        public string GenerateToken(User user);
    }
}
