using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.DataAccess.Postgres.Entities
{
    [Table("user_groups")]
    public class UserGroupEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Group")]
        [Column("group_id")]
        public int GroupId { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        public UserEntity User { get; set; }

        public GroupEntity Group { get; set; }
    }
}
