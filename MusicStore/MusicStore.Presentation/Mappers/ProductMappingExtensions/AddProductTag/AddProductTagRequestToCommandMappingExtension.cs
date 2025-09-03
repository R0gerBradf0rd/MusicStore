using MusicStore.Application.Products.Commands.AddProductTag;
using MusicStore.Presentation.Contracts.Products.AddProductTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.AddProductTag
{
    public static class AddProductTagRequestToCommandMappingExtension
    {
        public static AddProductTagCommand ToAddProductTagCommand( this AddProductTagRequest request )
        {
            return new AddProductTagCommand( request.TagId, request.ProductId );
        }
    }
}
