using library.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace library.data
{
    public class LibraryDBContext(DbContextOptions<LibraryDBContext> options, IConfiguration config) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c=> c.Books);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.ID);
            base.OnModelCreating(modelBuilder);
        }

    }
}
