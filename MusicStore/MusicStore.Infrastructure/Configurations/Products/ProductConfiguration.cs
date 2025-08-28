using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure( EntityTypeBuilder<Product> builder )
        {
            builder.ToTable( "Products" );

            builder.HasKey( p => p.Id );

            builder.Property( p => p.Name )
                .HasMaxLength( 300 )
                .IsRequired();

            builder.Property( p => p.Description )
                .HasMaxLength( 5000 );

            builder.Property( p => p.PriceCurrencyCode )
                .HasMaxLength( 5 )
                .IsRequired();

            builder.Property( p => p.Price )
                .IsRequired();

            builder.Property( p => p.ImageURL )
                .HasMaxLength( 1000 )
                .IsRequired();

            builder.HasMany( p => p.ProductTags )
                .WithOne()
                .HasForeignKey( pt => pt.ProductId );

            builder.HasMany<ProductWarehouse>()
                .WithOne()
                .HasForeignKey( pw => pw.ProductId );
        }
    }
}
