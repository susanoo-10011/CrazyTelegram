using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.Infrastructure.Data.Entities

{
    [Table("users")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("login")]
        public string Login { get; set; } = string.Empty;

        [Timestamp]
        [Column("create_at")]
        public DateTime CreatedAt { get; set; }

    }
}
