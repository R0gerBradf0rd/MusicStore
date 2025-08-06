using MusicStore.Application.Products.Dtos;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Mappers
{
    public static class ProductMappingExtensions
    {
        public static ProductDto ToDto( this Product product )
        {
            return new ProductDto
            (
                product.Name,
                product.Description,
                product.Price,
                product.PriceCurrencyCode,
                product.ImageURL,
                product.ProductTags
            );
        }
    }
}
