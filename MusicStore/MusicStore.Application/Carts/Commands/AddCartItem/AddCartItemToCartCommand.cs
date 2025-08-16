using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.AddCartItem
{
    public class AddCartItemToCartCommand : ICommand<Result<CartItem>>
    {
        public Guid CartId { get; }

        public Guid ProductId { get; }

        public AddCartItemToCartCommand( Guid cartId, Guid productId )
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
