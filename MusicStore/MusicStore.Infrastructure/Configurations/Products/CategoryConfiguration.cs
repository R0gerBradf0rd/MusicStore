using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Infrastructure.Configurations.Products
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure( EntityTypeBuilder<Category> builder )
        {
            builder.ToTable( "Categories" );

            builder.HasKey( c => c.Id );

            builder.Property( c => c.Name )
                .HasMaxLength( 300 )
                .IsRequired();
        }
    }
}
