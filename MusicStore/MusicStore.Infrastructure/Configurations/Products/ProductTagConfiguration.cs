using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure( EntityTypeBuilder<ProductTag> builder )
        {
            builder.ToTable( "productTag" );

            builder.HasKey( pt => new { pt.TagId, pt.ProductId } );

            builder.Property( pt => pt.TagId )
                .IsRequired();

            builder.Property( pt => pt.ProductId )
                .IsRequired();

            builder.Property( pt => pt.TagId )
                .IsRequired();
        }
    }
}
