using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.AddProductToWarehouse
{
    public class AddProductToWarehouseCommand : ICommand<Result<ProductWarehouse>>
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public AddProductToWarehouseCommand( Guid productId, Guid warehouseId, int warehouseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehouseProductQuantity;
        }
    }
}
