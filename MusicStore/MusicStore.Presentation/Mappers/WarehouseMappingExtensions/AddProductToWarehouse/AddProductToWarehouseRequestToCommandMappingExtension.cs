using MusicStore.Application.Warehouses.Commands.AddProductToWarehouse;
using MusicStore.Presentation.Contracts.Warehouses.AddProductToWarehouse;

namespace MusicStore.Presentation.Mappers.WarehouseMappingExtensions.AddProductToWarehouse
{
    public static class AddProductToWarehouseRequestToCommandMappingExtension
    {
        public static AddProductToWarehouseCommand ToAddProductToWarehouseCommand( this AddProductToWarehouseRequest request )
        {
            return new AddProductToWarehouseCommand( request.ProductId, request.WarehouseId, request.WarehouseProductQuantity );
        }
    }
}
