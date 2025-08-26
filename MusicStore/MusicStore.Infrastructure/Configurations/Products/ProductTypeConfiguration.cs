using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure( EntityTypeBuilder<ProductType> builder )
        {
            builder.ToTable( "productType" );

            builder.HasKey( pt => pt.Id );

            builder.Property( pt => pt.Name )
                .HasMaxLength( 20 )
                .IsRequired();

            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey( pt => pt.CategoryId );

            builder.HasMany<Product>()
                .WithOne()
                .HasForeignKey( p => p.ProductTypeId );
        }
    }
}
