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
            //add-migration update -contex CrazyTelegramDbContextDatabase.Migrate();
        }

        public DbSet<UserEntity> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
