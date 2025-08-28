using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.ToTable( "Tags" );

            builder.HasKey( t => t.Id );

            builder.Property( t => t.Value )
                .HasMaxLength( 200 )
                .IsRequired();

            builder.HasMany<ProductTag>()
                .WithOne()
                .HasForeignKey( pt => pt.TagId );
        }
    }
}
