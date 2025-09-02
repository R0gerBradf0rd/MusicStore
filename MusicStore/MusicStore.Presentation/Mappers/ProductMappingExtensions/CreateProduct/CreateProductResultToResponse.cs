using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.CreateProduct;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProduct
{
    public static class CreateProductResultToResponse
    {
        public static CreateProductResponse ToCreateProductResponse( this Result<Guid> result )
        {
            return new CreateProductResponse( result.Value );
        }
    }
}
