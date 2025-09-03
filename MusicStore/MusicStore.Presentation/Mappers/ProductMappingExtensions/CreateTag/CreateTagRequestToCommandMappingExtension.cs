using MusicStore.Application.Products.Commands.CreateTag;
using MusicStore.Presentation.Contracts.Products.CreateTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateTag
{
    public static class CreateTagRequestToCommandMappingExtension
    {
        public static CreateTagCommand ToCreateTagCommand( this CreateTagRequest request )
        {
            return new CreateTagCommand( request.Value );
        }
    }
}
