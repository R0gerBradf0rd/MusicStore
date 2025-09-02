using MusicStore.Application.Carts.Commands.RemoveCartItem;
using MusicStore.Presentation.Contracts.Carts.RemoveCartItem;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.RemoveCartItem
{
    public static class RemoveCartItemRequestToCommand
    {
        public static RemoveCartItemCommand ToRemoveCartItemCommand( this RemoveCartItemRequest request )
        {
            return new RemoveCartItemCommand( request.Id );
        }
    }
}
