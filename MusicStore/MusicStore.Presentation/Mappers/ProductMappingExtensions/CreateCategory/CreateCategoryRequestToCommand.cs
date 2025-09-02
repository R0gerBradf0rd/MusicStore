using MusicStore.Application.Products.Commands.CreateCategory;
using MusicStore.Presentation.Contracts.Products.CreateCategory;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateCategory
{
    public static class CreateCategoryRequestToCommand
    {
        public static CreateCategoryCommand ToCreateCategoryCommand( this CreateCategoryRequest request )
        {
            return new CreateCategoryCommand( request.Name );
        }
    }
}
