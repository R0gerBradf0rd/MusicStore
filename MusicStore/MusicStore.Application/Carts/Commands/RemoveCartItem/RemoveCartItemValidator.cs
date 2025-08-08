using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.RemoveCartItem
{
    public class RemoveCartItemValidator : IAsyncValidator<RemoveCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public RemoveCartItemValidator( ICartRepository cartRepository, IProductRepository productRepository )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Result> ValidateAsync( RemoveCartItemCommand request )
        {
            if ( request.CartId == Guid.Empty )
            {
                return Result.Failure( "Id корзины не может быть пустым!" );
            }
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }

            bool isCartExist = await _cartRepository.ContainsAsync( c => c.Id == request.CartId );

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );

            if ( !isCartExist )
            {
                return Result.Failure( "Корзины с таким Id несуществует!" );
            }
            if ( !isProductExist )
            {
                return Result.Failure( "Продукта с таким Id несуществует!" );
            }

            Cart cart = await _cartRepository.GetByIdOrDefaultAsync( request.CartId );

            CartItem cartItem = new CartItem( request.ProductId, request.CartId );

            if ( !cart.CartItems.Contains( cartItem ) )
            {
                return Result.Failure( "Такого продукта нет в данной корзине!" );
            }

            return Result.Success();
        }
    }
}
