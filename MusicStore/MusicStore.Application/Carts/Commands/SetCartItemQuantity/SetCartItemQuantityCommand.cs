using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.SetCartItemQuantity
{
    public class SetCartItemQuantityCommand : ICommand<Result<string>>
    {
        public Guid Id { get; }

        public int Quantity { get; }

        public SetCartItemQuantityCommand( Guid id, int quantity )
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
