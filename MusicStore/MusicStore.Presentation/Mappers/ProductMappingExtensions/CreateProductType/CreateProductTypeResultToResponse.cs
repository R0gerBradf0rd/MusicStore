using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.CreateProductType;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProductType
{
    public static class CreateProductTypeResultToResponse
    {
        public static CreateProductTypeResponse ToCreateProductTypeResponse( this Result<Guid> result )
        {
            return new CreateProductTypeResponse( result.Value );
        }
    }
}
