using Microsoft.EntityFrameworkCore;

namespace RentSystem.Models
{
    public class RentDbContext : DbContext

    {
        public RentDbContext(DbContextOptions<RentDbContext> options)  
            : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
                modelBuilder.Entity<Book>()
                    .HasOne(b => b.Customer)
                    .WithMany(a => a.BooksRented)
                    .OnDelete(DeleteBehavior.SetNull);
            
        }

    }
}
