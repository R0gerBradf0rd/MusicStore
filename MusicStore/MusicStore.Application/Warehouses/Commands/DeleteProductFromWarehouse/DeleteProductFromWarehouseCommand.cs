using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Warehouses.Commands.DeleteProductFromWarehouse
{
    public class DeleteProductFromWarehouseCommand : ICommand<Result<string>>
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public DeleteProductFromWarehouseCommand( Guid productId, Guid warehouseId )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
        }
    }
}
