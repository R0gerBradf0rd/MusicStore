namespace MusicStore.Presentation.Contracts.Warehouses.CreateWarehouse
{
    public class CreateWarehouseResponse
    {
        public Guid WarehouseId { get; }

        public CreateWarehouseResponse( Guid warehouseId )
        {
            WarehouseId = warehouseId;
        }
    }
}
