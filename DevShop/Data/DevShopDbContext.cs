using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevShop.Data.Models;
using DevShop.Data.Models.JoinTables;

namespace DevShop.Data
{
    public class DevShopDbContext : IdentityDbContext<ExtendedIdentityUser>
    {
        public DevShopDbContext(DbContextOptions<DevShopDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new {ba.BookId, ba.AuthorId});
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Users)
                .WithOne(c => c.Country);
            modelBuilder.Entity<ExtendedIdentityUser>()
                .HasOne(c => c.UserCart)
                .WithOne(u => u.User)
                .HasForeignKey<Cart>(b => b.UserRef);
        }
    }
}
