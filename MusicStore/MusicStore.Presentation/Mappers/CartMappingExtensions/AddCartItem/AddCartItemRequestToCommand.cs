using MusicStore.Application.Carts.Commands.AddCartItem;
using MusicStore.Presentation.Contracts.Carts.AddCartItem;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.AddCartItem
{
    public static class AddCartItemRequestToCommand
    {
        public static AddCartItemToCartCommand ToAddCartItemToCartCommand( this AddCartItemRequest request )
        {
            return new AddCartItemToCartCommand( request.CartId, request.ProductId );
        }
    }
}
