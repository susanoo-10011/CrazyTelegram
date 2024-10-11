namespace CrazyTelegram.AuthenticationService.Models
{
    public class UserDTO
    {

        public string UserName { get;  set; }

        public string PasswordHash { get;  set; }

        public string Email { get;  set; }
        public string Login { get; set; }
    }
}
