using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrazyTelegram.Infrastructure.Data.Entities
{
    [Table("groups")]
    public class GroupEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("create_date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
