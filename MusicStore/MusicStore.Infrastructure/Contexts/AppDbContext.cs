using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Domain.Entities.Products;
using MusicStore.Domain.Entities.Reviews;
using MusicStore.Domain.Entities.Users;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Infrastructure.Configurations.Carts;
using MusicStore.Infrastructure.Configurations.Orders;
using MusicStore.Infrastructure.Configurations.Products;
using MusicStore.Infrastructure.Configurations.Reviews;
using MusicStore.Infrastructure.Configurations.Users;
using MusicStore.Infrastructure.Configurations.Warehouses;

namespace MusicStore.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Warehouse> Warehouses { get; set; }
        DbSet<ProductWarehouse> ProductWarehouses { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Tag> Tags { get; set; }
        DbSet<ProductTag> ProductTags { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }

        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }

        DbSet<CartItem> CartItems { get; set; }
        DbSet<Cart> Carts { get; set; }

        public AppDbContext( DbContextOptions<AppDbContext> options )
            : base( options )
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new UserConfiguration() );

            modelBuilder.ApplyConfiguration( new WarehouseConfiguration() );
            modelBuilder.ApplyConfiguration( new ProductWarehouseConfiguration() );

            modelBuilder.ApplyConfiguration( new ReviewConfiguration() );

            modelBuilder.ApplyConfiguration( new TagConfiguration() );
            modelBuilder.ApplyConfiguration( new ProductTypeConfiguration() );
            modelBuilder.ApplyConfiguration( new ProductTagConfiguration() );
            modelBuilder.ApplyConfiguration( new ProductConfiguration() );
            modelBuilder.ApplyConfiguration( new CategoryConfiguration() );

            modelBuilder.ApplyConfiguration( new OrderItemConfiguration() );
            modelBuilder.ApplyConfiguration( new OrderConfiguration() );

            modelBuilder.ApplyConfiguration( new CartItemConfiguration() );
            modelBuilder.ApplyConfiguration( new CartConfiguration() );

            base.OnModelCreating( modelBuilder );
        }
    }
}
