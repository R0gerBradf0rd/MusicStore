namespace MusicStore.Domain.Entities
{
    public class ProductWarehouse
    {
        public Guid ProductId { get; }

        public Guid WarehouseId { get; }

        public int Quantity { get; }
    }
}
