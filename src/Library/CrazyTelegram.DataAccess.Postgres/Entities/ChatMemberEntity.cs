using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    public class ChatMemberEntity
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }

        [Timestamp]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ChatId")]
        public ChatEntity Chat { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
