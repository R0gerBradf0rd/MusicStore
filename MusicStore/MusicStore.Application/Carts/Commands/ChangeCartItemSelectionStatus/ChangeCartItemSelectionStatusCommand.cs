using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.ChangeCartItemSelectionStatus
{
    public class ChangeCartItemSelectionStatusCommand : ICommand<Result<string>>
    {
        public Guid CartItemId { get; }

        public ChangeCartItemSelectionStatusCommand( Guid cartItemId )
        {
            CartItemId = cartItemId;
        }
    }
}
