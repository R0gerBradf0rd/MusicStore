using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.TakeProductFromWarehouse
{
    public class TakeProductFromWarehouseCommand : ICommand<Result<ProductWarehouse>>
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public TakeProductFromWarehouseCommand( Guid productId, Guid warehouseId, int warehouseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehouseProductQuantity;
        }
    }
}
