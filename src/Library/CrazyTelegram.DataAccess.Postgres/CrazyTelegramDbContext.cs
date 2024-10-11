using CrazyTelegram.DataAccess.Postgres.Configurations;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrazyTelegram.DataAccess.Postgres
{
    public class CrazyTelegramDbContext : DbContext
    {
        // add-migration update -contex CrazyTelegramDbContext \\
        // update-database \\

        //-----------------------------------------------------\\
        public CrazyTelegramDbContext(DbContextOptions<CrazyTelegramDbContext> options) : base(options)
        {
           // Database.Migrate();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<MessageRecipientEntity> MessageRecipients { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
