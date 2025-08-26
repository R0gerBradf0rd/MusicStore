using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Infrastructure.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable( "users" );

            builder.HasKey( u => u.Id );

            builder.Property( u => u.Name )
                .HasMaxLength( 50 )
                .IsRequired();

            builder.Property( u => u.Email )
                .HasMaxLength( 50 )
                .IsRequired();

            builder.Property( u => u.UserRole )
               .HasMaxLength( 50 )
               .IsRequired();
        }
    }
}
