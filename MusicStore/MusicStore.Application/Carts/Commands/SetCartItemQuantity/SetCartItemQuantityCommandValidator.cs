using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.SetCartItemQuantity
{
    public class SetCartItemQuantityCommandValidator : IAsyncValidator<SetCartItemQuantityCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public SetCartItemQuantityCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result> ValidateAsync( SetCartItemQuantityCommand request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }
            if ( request.Quantity < 1 )
            {
                return Result.Failure( "Количество товара должно быть больше нуля!" );
            }
            if ( request.Quantity > CartItem.CartItemQuantityLimit )
            {
                return Result.Failure( $"Количество товара не должно быть больше {CartItem.CartItemQuantityLimit}!" );
            }

            bool isCartItemExists = await _cartItemRepository.ContainsAsync( ci => ci.Id == request.Id );

            if ( !isCartItemExists )
            {
                return Result.Failure( "Данного элемента корзины несуществует!" );
            }

            return Result.Success();
        }
    }
}
