using CrazyTelegram.DataAccess.Postgres.Configurations;
using CrazyTelegram.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace CrazyTelegram.DataAccess.Postgres
{
    public class CrazyTelegramDbContext(DbContextOptions<CrazyTelegramDbContext> options) : DbContext(options)
    {
        // add-migration create -contex CrazyTelegramDbContext \\

        //-----------------------------------------------------\\

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
