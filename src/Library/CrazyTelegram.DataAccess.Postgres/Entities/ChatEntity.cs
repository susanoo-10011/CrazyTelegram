using System.ComponentModel.DataAnnotations;

namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    public class ChatEntity
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public bool IsPrivate { get; set; }

        [Timestamp]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Timestamp]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
