using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.AddCartItem
{
    public class AddCartItemToCartCommandValidator : IAsyncValidator<AddCartItemToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddCartItemToCartCommandValidator( ICartRepository cartRepository, IProductRepository productRepository )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<Result> ValidateAsync( AddCartItemToCartCommand request )
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

            if ( !isCartExist )
            {
                return Result.Failure( "Корзины с таким Id несуществует!" );
            }

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );

            if ( !isProductExist )
            {
                return Result.Failure( "Продукта с таким Id несуществует!" );
            }

            return Result.Success();
        }
    }
}
