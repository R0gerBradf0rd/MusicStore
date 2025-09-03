using MusicStore.Application.Warehouses.Commands.CreateWarehouse;
using MusicStore.Presentation.Contracts.Warehouses.CreateWarehouse;

namespace MusicStore.Presentation.Mappers.WarehouseMappingExtensions.CreateWarehouse
{
    public static class CreateWarehouseRequestToCommandMappingExtension
    {
        public static CreateWarehouseCommand ToCreateWarehouseCommand( this CreateWarehouseRequest request )
        {
            return new CreateWarehouseCommand( request.Address );
        }
    }
}
