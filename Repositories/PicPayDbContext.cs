using Microsoft.EntityFrameworkCore;

namespace picpay;

public class PicPayDbContext : DbContext
{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/picpay.db");
        }

        public DbSet<User> Users { get; set; }
}
