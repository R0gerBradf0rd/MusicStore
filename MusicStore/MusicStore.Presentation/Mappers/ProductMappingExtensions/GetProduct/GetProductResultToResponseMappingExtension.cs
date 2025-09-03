using MusicStore.Application.Products.Dtos;
using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.GetProduct;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.GetProduct
{
    public static class GetProductResultToResponse
    {
        public static GetProductResponse ToGetProductResponse( this Result<ProductDto> result )
        {
            return new GetProductResponse(
                result.Value.Name,
                result.Value.Description,
                result.Value.Price,
                result.Value.PriceCurrencyCode,
                result.Value.ImageURL,
                result.Value.ProductTags );
        }
    }
}
