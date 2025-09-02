using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Presentation.Contracts.Warehouses.AddProductToWarehouse;

namespace MusicStore.Presentation.Mappers.WarehouseMappingExtensions.AddProductToWarehouse
{
    public static class AddProductToWarehouseResultToResponse
    {
        public static AddProductToWarehouseResponse ToAddProductToWarehouseResponse( this Result<ProductWarehouse> result )
        {
            return new AddProductToWarehouseResponse(
                result.Value.ProductId,
                result.Value.WarehouseId,
                result.Value.Quantity );
        }
    }
}
