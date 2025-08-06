using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.ChangeCartItemSelectionStatus
{
    public class ChangeCartItemSelectionStatusCommandValidator : IAsyncValidator<ChangeCartItemSelectionStatusCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public ChangeCartItemSelectionStatusCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result> ValidateAsync( ChangeCartItemSelectionStatusCommand request )
        {
            if ( request.CartItemId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isCartItemExist = await _cartItemRepository.ContainsAsync( ci => ci.Id == request.CartItemId );

            if ( !isCartItemExist )
            {
                return Result.Failure( "Такого элемента корзины несуществует!" );
            }

            return Result.Success();
        }
    }
}
