namespace MusicStore.Presentation.Contracts.Warehouses.AddProductToWarehouse
{
    public class AddProductToWarehouseResponse
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }

        public AddProductToWarehouseResponse(
            Guid productId,
            Guid warehouseId,
            int warehouseProductQuantity )
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            WarehouseProductQuantity = warehouseProductQuantity;
        }
    }
}
