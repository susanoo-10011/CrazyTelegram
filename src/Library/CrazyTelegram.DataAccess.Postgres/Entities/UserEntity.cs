namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

    }
}
