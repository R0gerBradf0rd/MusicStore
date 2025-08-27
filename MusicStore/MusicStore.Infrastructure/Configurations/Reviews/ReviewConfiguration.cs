using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Products;
using MusicStore.Domain.Entities.Reviews;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Infrastructure.Configurations.Reviews
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure( EntityTypeBuilder<Review> builder )
        {
            builder.ToTable( "Reviews" );

            builder.HasKey( r => r.Id );

            builder.Property( r => r.Comment )
                .HasMaxLength( 10000 );

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey( r => r.UserId )
                .OnDelete( DeleteBehavior.Cascade );

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey( r => r.ProductId )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}
