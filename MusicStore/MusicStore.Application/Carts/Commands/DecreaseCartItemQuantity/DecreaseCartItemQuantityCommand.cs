using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.DecreaseCartItemQuantity
{
    public class DecreaseCartItemQuantityCommand : ICommand<Result<string>>
    {
        public Guid Id { get; }

        public DecreaseCartItemQuantityCommand( Guid id )
        {
            Id = id;
        }
    }
}
