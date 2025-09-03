using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.CreateProductType;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProductType
{
    public static class CreateProductTypeResultToResponseMappingExtension
    {
        public static CreateProductTypeResponse ToCreateProductTypeResponse( this Result<Guid> result )
        {
            return new CreateProductTypeResponse( result.Value );
        }
    }
}
