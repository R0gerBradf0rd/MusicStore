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
        public DbSet<User> Users { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public AppDbContext( DbContextOptions<AppDbContext> options )
            : base( options ) { }

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
