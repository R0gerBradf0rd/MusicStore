using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Warehouses.Commands.DecriseProductInWarehouse
{
    public class DecriseProductInWarehouseCommand : ICommand<Result<string>>
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public DecriseProductInWarehouseCommand( Guid productId, Guid warehouseId, int warehoseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehoseProductQuantity;
        }
    }
}
