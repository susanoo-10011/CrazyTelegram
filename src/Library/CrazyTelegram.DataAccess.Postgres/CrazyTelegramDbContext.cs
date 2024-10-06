using CrazyTelegram.DataAccess.Postgres.Configurations;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace CrazyTelegram.DataAccess.Postgres
{
    public class CrazyTelegramDbContext : DbContext
    {
        // add-migration update (update-это название миграции) -contex CrazyTelegramDbContext \\
        // update-database \\

        //-----------------------------------------------------\\
        public CrazyTelegramDbContext(DbContextOptions<CrazyTelegramDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
