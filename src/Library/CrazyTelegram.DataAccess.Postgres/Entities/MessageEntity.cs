using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }
        [Required]
        public string Content { get; set; }

        [Timestamp]
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ChatId")]
        public ChatEntity Chat { get; set; }

        [ForeignKey("SenderId")]
        public UserEntity Sender { get; set; }
    }
}
