using MusicStore.Application.Carts.Commands.SetCartItemSelectionStatus;
using MusicStore.Presentation.Contracts.Carts.SetCartItemSelectionStatus;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemSelectionStatus
{
    public static class SetCartItemSelectionStatusRequestToCommand
    {
        public static SetCartItemSelectionStatusCommand ToSetCartItemSelectionStatusCommand( this SetCartItemSelectionStatusRequest request )
        {
            return new SetCartItemSelectionStatusCommand( request.CartItemId, request.SelectionStatus );
        }
    }
}
