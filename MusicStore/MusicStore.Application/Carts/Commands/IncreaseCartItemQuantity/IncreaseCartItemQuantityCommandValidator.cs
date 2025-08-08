using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.IncreaseCartItemQuantity
{
    public class IncreaseCartItemQuantityCommandValidator : IAsyncValidator<IncreaseCartItemQuantityCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public IncreaseCartItemQuantityCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result> ValidateAsync( IncreaseCartItemQuantityCommand request )
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
