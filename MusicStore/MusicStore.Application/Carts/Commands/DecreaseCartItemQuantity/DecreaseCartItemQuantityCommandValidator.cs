using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.DecreaseCartItemQuantity
{
    public class DecreaseCartItemQuantityCommandValidator : IAsyncValidator<DecreaseCartItemQuantityCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DecreaseCartItemQuantityCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result> ValidateAsync( DecreaseCartItemQuantityCommand request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isCartItemExist = await _cartItemRepository.ContainsAsync( ci => ci.Id == request.Id );

            if ( !isCartItemExist )
            {
                return Result.Failure( "Данного элемента корзины несуществует!" );
            }

            return Result.Success();
        }
    }
}
