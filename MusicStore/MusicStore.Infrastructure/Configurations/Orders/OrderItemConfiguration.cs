using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Orders
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure( EntityTypeBuilder<OrderItem> builder )
        {
            builder.ToTable( "OrderItems" );

            builder.HasKey( oi => oi.Id );

            builder.Property( oi => oi.OrderId )
                .IsRequired();

            builder.Property( oi => oi.ProductId )
                .IsRequired();

            builder.Property( oi => oi.Quantity )
                .IsRequired();

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey( oi => oi.ProductId );

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey( oi => oi.OrderId );
        }
    }
}
