using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Infrastructure.Configurations.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure( EntityTypeBuilder<Order> builder )
        {
            builder.ToTable( "orders" );

            builder.HasKey( o => o.Id );

            builder.Property( o => o.OrderNumber )
                .IsRequired();

            builder.Property( o => o.TotalPrice )
                .IsRequired();

            builder.Property( o => o.TotalPriceCurrencyCode )
                .IsRequired();

            builder.Property( o => o.ShippingAddress )
                .HasMaxLength( 200 )
                .IsRequired();

            builder.Property( o => o.CreationDate )
                .IsRequired();

            builder.Property( o => o.AssemblyProcessStartDate );

            builder.Property( o => o.ReadyToShipDate );

            builder.Property( o => o.ShipmentDate );

            builder.Property( o => o.DeliveryDate );

            builder.Property( o => o.Status );

            builder.Property( o => o.UserId )
                .IsRequired();

            builder.Property( o => o.CartId )
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey( o => o.UserId );

            builder.HasOne<Cart>()
                .WithOne()
                .HasForeignKey<Order>( o => o.CartId );
        }
    }
}
