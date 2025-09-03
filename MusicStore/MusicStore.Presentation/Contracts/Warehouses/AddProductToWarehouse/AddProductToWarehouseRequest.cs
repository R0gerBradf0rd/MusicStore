namespace MusicStore.Presentation.Contracts.Warehouses.AddProductToWarehouse
{
    public class AddProductToWarehouseRequest
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public AddProductToWarehouseRequest( Guid productId, Guid warehouseId, int warehouseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehouseProductQuantity;
        }
    }
}
