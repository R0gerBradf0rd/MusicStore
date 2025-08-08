using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.SetCartItemSelectionStatus
{
    public class SetCartItemSelectionStatusCommand : ICommand<Result<string>>
    {
        public Guid CartItemId { get; }

        public CartItemSelectionStatus SelectionStatus { get; }

        public SetCartItemSelectionStatusCommand( Guid cartItemId, CartItemSelectionStatus selectionStatus )
        {
            CartItemId = cartItemId;
            SelectionStatus = selectionStatus;
        }
    }
}
