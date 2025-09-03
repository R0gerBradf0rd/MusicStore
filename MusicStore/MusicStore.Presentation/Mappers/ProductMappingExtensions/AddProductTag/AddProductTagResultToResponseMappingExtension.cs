using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;
using MusicStore.Presentation.Contracts.Products.AddProductTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.AddProductTag
{
    public static class AddProductTagResultToResponseMappingExtension
    {
        public static AddProductTagResponse ToAddProductTagResponse( this Result<ProductTag> result )
        {
            return new AddProductTagResponse( result.Value.TagId, result.Value.ProductId );
        }
    }
}
