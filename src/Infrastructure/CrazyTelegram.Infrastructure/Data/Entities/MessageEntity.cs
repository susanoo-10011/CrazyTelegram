using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.Infrastructure.Data.Entities

{
    [Table("messages")]
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("subject")]
        public required string Subject { get; set; }

        [Required]
        [Column("creator_id")]
        [ForeignKey("User")]
        public int CreatorId { get; set; }

        [Required]
        [Column("message_body")]
        public required string MessageBody { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        public required UserEntity User { get; set; }
    }
}
