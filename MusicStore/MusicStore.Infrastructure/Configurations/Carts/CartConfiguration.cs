using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Infrastructure.Configurations.Carts
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure( EntityTypeBuilder<Cart> builder )
        {
            builder.ToTable( "carts" );

            builder.HasKey( c => c.Id );

            builder.Property( c => c.UserId )
                .IsRequired();

            builder.Property( c => c.TotalPrice )
                .IsRequired();

            builder.HasMany( c => c.CartItems )
                .WithOne()
                .HasForeignKey( ci => ci.CartId );

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Cart>( c => c.UserId );
        }
    }
}
