using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Infrastructure.Configurations.Warehouses
{
    public class ProductWarehouseConfiguration : IEntityTypeConfiguration<ProductWarehouse>
    {
        public void Configure( EntityTypeBuilder<ProductWarehouse> builder )
        {
            builder.ToTable( "ProductWarehouse" );

            builder.HasKey( pw => new { pw.ProductId, pw.WarehouseId } );

            builder.Property( pw => pw.ProductId )
                .IsRequired();

            builder.Property( pw => pw.WarehouseId )
                .IsRequired();

            builder.Property( pw => pw.Quantity )
                .IsRequired();
        }
    }
}
