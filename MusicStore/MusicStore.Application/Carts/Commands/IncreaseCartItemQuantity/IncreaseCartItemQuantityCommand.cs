using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.IncreaseCartItemQuantity
{
    public class IncreaseCartItemQuantityCommand : ICommand<Result<string>>
    {
        public Guid Id { get; }

        public IncreaseCartItemQuantityCommand( Guid id )
        {
            Id = id;
        }
    }
}
