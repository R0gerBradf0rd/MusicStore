using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Infrastructure.Configurations.Carts
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure( EntityTypeBuilder<CartItem> builder )
        {
            builder.ToTable( "CartItems" );

            builder.HasKey( ci => ci.Id );

            builder.Property( ci => ci.Quantity )
                .IsRequired();

            builder.Property( ci => ci.CartId )
                .IsRequired();

            builder.Property( ci => ci.ProductId )
                .IsRequired();

            builder.Property( ci => ci.Quantity )
                .IsRequired();

            builder.HasOne( ci => ci.Product )
                .WithMany()
                .HasForeignKey( ci => ci.ProductId );
        }
    }
}
