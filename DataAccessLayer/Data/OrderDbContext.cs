using Microsoft.EntityFrameworkCore;
using EntityLayer.Models;
using Entitites.Models;

namespace DataAccessLayer.Data
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WishlistCollection> WishlistCollections { get; set; }
        public DbSet<WishlistItems> WishlistItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItems>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
           .UseLazyLoadingProxies() // Enables lazy loading
           .UseSqlServer("name=ConnectionStrings:OrderingBookingConnectionString");
        }

    }
}
