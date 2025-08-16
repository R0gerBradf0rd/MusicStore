using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.RemoveCartItem
{
    public class RemoveCartItemCommand : ICommand<Result<CartItem>>
    {
        public Guid Id { get; }

        public RemoveCartItemCommand( Guid id )
        {
            Id = id;
        }
    }
}
