using MusicStore.Application.Products.Queries.GetProduct;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.GetProduct
{
    public static class GetProductRequestToQuery
    {
        public static GetProductQuery ToGetProductQuery( this Guid productId )
        {
            return new GetProductQuery( productId );
        }
    }
}
