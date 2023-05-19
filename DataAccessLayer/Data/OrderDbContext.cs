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
        public DbSet<OrderLineItems> OrderLines { get; set; }
        public DbSet<WishList> Wishlists { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ShippngAddress> ShippngAddress { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<ShippingMethod>().HasData(shippingMethods);

            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    OrderLineItemsId = Guid.NewGuid(),
                    ProductQuantity = 1,
                    ProductPrice=24999
                } ,
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductQuantity=1,
                    OrderLineItemsId=Guid.NewGuid(),
                    ProductPrice=9999
                }
            };
            modelBuilder.Entity<Product>().HasData(products);

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
            modelBuilder.Entity<ShippngAddress>().HasData(shippingAddress);

            var users = new List<User>
            {
                new User
                {
                    UserId=Guid.NewGuid(),
                },
                 new User
                {
                    UserId=Guid.NewGuid(),
                },
            };
            modelBuilder.Entity<User>().HasData(users);

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
            modelBuilder.Entity<Payment>().HasData(payments);
        }

    }
}
