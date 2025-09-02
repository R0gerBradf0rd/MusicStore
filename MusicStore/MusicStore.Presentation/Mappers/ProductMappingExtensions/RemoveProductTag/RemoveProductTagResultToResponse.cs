using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.RemoveProductTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.RemoveProductTag
{
    public static class RemoveProductTagResultToResponse
    {
        public static RemoveProductTagResponse ToRemoveProductTagResponse( this Result<MusicStore.Domain.Entities.Products.ProductTag> result )
        {
            return new RemoveProductTagResponse( result.Value.TagId, result.Value.ProductId );
        }
    }
}
