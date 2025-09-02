using MusicStore.Application.Products.Commands.RemoveProductTag;
using MusicStore.Presentation.Contracts.Products.RemoveProductTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.RemoveProductTag
{
    public static class RemoveProductTagRequestToCommand
    {
        public static RemoveProductTagCommand ToRemoveProductTagCommand( this RemoveProductTagRequest request )
        {
            return new RemoveProductTagCommand( request.TagId, request.ProductId );
        }
    }

}
