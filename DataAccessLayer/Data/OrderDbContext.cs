using Microsoft.EntityFrameworkCore;
using EntityLayer.Models;

namespace DataAccessLayer.Data
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<WishList> Wishlists { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ShippngAddress> ShippngAddress { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItems>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            var shippingMethods = new List<ShippingMethod>
            {
                new ShippingMethod
                {
                    ShippingMethodId=Guid.NewGuid(),
                    Name="Fast Delivery",
                    price=199
                },
                new ShippingMethod
                {
                    ShippingMethodId=Guid.NewGuid(),
                    Name="Normal Delivery",
                    price=49
                },
                new ShippingMethod
                {
                    ShippingMethodId=Guid.NewGuid(),
                    Name="Self pickup",
                    price=0
                }
            };

            var shippingAddress = new List<ShippngAddress>
            {
                new ShippngAddress
                {
                    ShippingAddressId=Guid.NewGuid()
                },
                new ShippngAddress
                {
                    ShippingAddressId=Guid.NewGuid()
                }
            };

            var users = new List<User>
            {
                new User
                {
                    UserId=21,
                },
                 new User
                {
                    UserId=22,
                },
            };

            var payments = new List<Payment>
            {
                new Payment
                {
                    PaymentId=Guid.NewGuid(),
                },
                new Payment
                {
                    PaymentId=Guid.NewGuid(),
                }
            };

            modelBuilder.Entity<ShippingMethod>().HasData(shippingMethods);
            modelBuilder.Entity<ShippngAddress>().HasData(shippingAddress);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Payment>().HasData(payments);
        }

    }
}
