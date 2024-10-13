using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyTelegram.Infrastructure.Data.Entities

{
    [Table("message_recipients")]
    public class MessageRecipientEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("recipient_id")]
        public int RecipientId { get; set; }

        [ForeignKey("UserGroup")]
        [Column("recipient_group_id")]
        public int RecipientGroupId { get; set; }

        [ForeignKey("Message")]
        [Column("message_id")]
        public int MessageId { get; set; }

        public MessageEntity Message { get; set; }

        public UserGroupEntity UserGroup { get; set; }

        public UserEntity User { get; set; }



    }
}
