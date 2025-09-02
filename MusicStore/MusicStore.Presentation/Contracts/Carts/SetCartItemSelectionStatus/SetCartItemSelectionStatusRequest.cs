using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Presentation.Contracts.Carts.SetCartItemSelectionStatus
{
    public class SetCartItemSelectionStatusRequest
    {
        public Guid CartItemId { get; }

        public CartItemSelectionStatus SelectionStatus { get; }

        public SetCartItemSelectionStatusRequest( Guid cartItemId, CartItemSelectionStatus selectionStatus )
        {
            CartItemId = cartItemId;
            SelectionStatus = selectionStatus;
        }
    }
}
