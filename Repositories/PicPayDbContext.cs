using Microsoft.EntityFrameworkCore;

namespace picpay;

public class PicPayDbContext : DbContext
{
        public PicPayDbContext(DbContextOptions<PicPayDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
}
