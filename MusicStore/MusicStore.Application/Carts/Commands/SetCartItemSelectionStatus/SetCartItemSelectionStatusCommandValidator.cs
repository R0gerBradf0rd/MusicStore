using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.SetCartItemSelectionStatus
{
    public class SetCartItemSelectionStatusCommandValidator : IAsyncValidator<SetCartItemSelectionStatusCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public SetCartItemSelectionStatusCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result> ValidateAsync( SetCartItemSelectionStatusCommand request )
        {
            if ( request.CartItemId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }
            if ( request.SelectionStatus != CartItemSelectionStatus.Selected || request.SelectionStatus != CartItemSelectionStatus.Unselected )
            {
                return Result.Failure( "Такого статуса несуществует!" );
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
