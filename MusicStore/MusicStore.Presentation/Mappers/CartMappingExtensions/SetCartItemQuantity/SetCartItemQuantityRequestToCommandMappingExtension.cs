using MusicStore.Application.Carts.Commands.SetCartItemQuantity;
using MusicStore.Presentation.Contracts.Carts.SetCartItemQuantity;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemQuantity
{
    public static class SetCartItemQuantityRequestToCommandMappingExtension
    {
        public static SetCartItemQuantityCommand ToSetCartItemQuantityCommand( this SetCartItemQuantityRequest request )
        {
            return new SetCartItemQuantityCommand( request.Id, request.Quantity );
        }
    }
}
