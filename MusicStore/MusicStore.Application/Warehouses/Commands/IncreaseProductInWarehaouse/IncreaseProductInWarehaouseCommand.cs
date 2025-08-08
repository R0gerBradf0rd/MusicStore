using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Warehouses.Commands.IncreaseProductInWarehaouse
{
    public class IncreaseProductInWarehaouseCommand : ICommand<Result<string>>
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public IncreaseProductInWarehaouseCommand( Guid productId, Guid warehouseId, int warehoseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehoseProductQuantity;
        }
    }
}
