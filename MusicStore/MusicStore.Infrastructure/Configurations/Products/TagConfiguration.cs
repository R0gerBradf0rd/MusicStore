using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.ToTable( "tags" );

            builder.HasKey( t => t.Id );

            builder.Property( t => t.Value )
                .HasMaxLength( 20 )
                .IsRequired();

            builder.HasMany<ProductTag>()
                .WithOne()
                .HasForeignKey( pt => pt.TagId );
        }
    }
}
