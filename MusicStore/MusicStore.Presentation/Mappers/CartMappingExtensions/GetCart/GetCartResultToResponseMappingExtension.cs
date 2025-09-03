using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Carts.GetCart;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.GetCart
{
    public static class GetCartResultToResponseMappingExtension
    {
        public static GetCartResponse ToGetCartResponse( this Result<Application.Carts.Dtos.CartDto> result )
        {
            return new GetCartResponse( result.Value.Items, result.Value.TotalPrice );
        }
    }
}
