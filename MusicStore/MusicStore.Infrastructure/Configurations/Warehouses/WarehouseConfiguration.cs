using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Infrastructure.Configurations.Warehouses
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure( EntityTypeBuilder<Warehouse> builder )
        {
            builder.ToTable( "warehouses" );

            builder.HasKey( w => w.Id );

            builder.Property( w => w.Address )
                .HasMaxLength( 200 )
                .IsRequired();

            builder.HasMany( w => w.ProductWarehouseItems )
                .WithOne()
                .HasForeignKey( pw => pw.WarehouseId );
        }
    }
}
