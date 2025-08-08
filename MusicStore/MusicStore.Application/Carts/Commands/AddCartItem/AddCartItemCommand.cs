using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.AddCartItem
{
    public class AddCartItemCommand : ICommand<Result<CartItem>>
    {
        public Guid CartId { get; }

        public Guid ProductId { get; }

        public AddCartItemCommand( Guid cartId, Guid productId )
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
