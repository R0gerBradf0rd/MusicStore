using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.CreateTag;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateTag
{
    public static class CreateTagResultToResponseMappingExtension
    {
        public static CreateTagResponse ToCreateTagResponse( this Result<Guid> result )
        {
            return new CreateTagResponse( result.Value );
        }
    }
}
