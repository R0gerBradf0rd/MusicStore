namespace MusicStore.Domain.Entities.Warehouses
{
    public class ProductWarehouse
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int WarehouseProductQuantity { get; }
    }
}
// IncreaseQuantityByOne
// DecreaseQuantityByOne