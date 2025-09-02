using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Products.CreateCategory;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateCategory
{
    public static class CreateCategoryResultToResponse
    {
        public static CreateCategoryResponse ToCreateCategoryResponse( this Result<Guid> result )
        {
            return new CreateCategoryResponse( result.Value );
        }
    }
}
