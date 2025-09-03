using MusicStore.Application.Products.Commands.CreateProduct;
using MusicStore.Presentation.Contracts.Products.CreateProduct;

namespace MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProduct
{
    public static class CreateProductRequestToCommandMappingExtension
    {
        public static CreateProductCommand ToCreateProductCommand( this CreateProductRequest request )
        {
            return new CreateProductCommand(
                request.Name,
                request.Description,
                request.Price,
                request.PriceCurrencyCode,
                request.ImageURL,
                request.ProductTypeId );
        }
    }
}
