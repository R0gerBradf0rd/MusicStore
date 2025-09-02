using MusicStore.Application.Products.Commands.CreateProductType;
using MusicStore.Presentation.Contracts.Products.CreateProductType;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProductType
{
    public static class CreateProductTypeRequestToCommand
    {
        public static CreateProductTypeCommand ToCreateProductTypeCommand( this CreateProductTypeRequest request )
        {
            return new CreateProductTypeCommand( request.Name, request.CategoryId );
        }
    }
}
