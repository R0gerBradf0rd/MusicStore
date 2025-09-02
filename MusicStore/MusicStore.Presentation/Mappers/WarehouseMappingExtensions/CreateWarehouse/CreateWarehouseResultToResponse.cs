using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Warehouses.CreateWarehouse;

namespace MusicStore.Presentation.Mappers.WarehouseMappingExtensions.CreateWarehouse
{
    public static class CreateWarehouseResultToResponse
    {
        public static CreateWarehouseResponse ToCreateWarehouseResponse( this Result<Guid> result )
        {
            return new CreateWarehouseResponse( result.Value );
        }
    }
}
