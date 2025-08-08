using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.RemoveCartItem
{
    public class RemoveCartItemCommand : ICommand<Result<CartItem>>
    {
        public Guid CartId { get; }

        public Guid ProductId { get; }

        public RemoveCartItemCommand( Guid cartId, Guid productId )
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
