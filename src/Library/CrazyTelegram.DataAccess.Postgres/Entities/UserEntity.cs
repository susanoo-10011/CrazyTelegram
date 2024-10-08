using System.ComponentModel.DataAnnotations;

namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Login { get; set; } = string.Empty;

        [Timestamp]
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

    }
}
