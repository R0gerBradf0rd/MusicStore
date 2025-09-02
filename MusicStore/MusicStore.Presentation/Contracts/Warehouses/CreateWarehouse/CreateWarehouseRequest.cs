namespace MusicStore.Presentation.Contracts.Warehouses.CreateWarehouse
{
    public class CreateWarehouseRequest
    {
        public string Address { get; }

        public CreateWarehouseRequest( string address )
        {
            Address = address;
        }
    }
}
