using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Infrastructure.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.ToTable( "Users" );

            builder.HasKey( u => u.Id );

            builder.Property( u => u.Name )
                .HasMaxLength( 300 )
                .IsRequired();

            builder.Property( u => u.Email )
                .HasMaxLength( 300 )
                .IsRequired();

            builder.Property( u => u.UserRole )
               .HasMaxLength( 300 )
               .IsRequired();
        }
    }
}
