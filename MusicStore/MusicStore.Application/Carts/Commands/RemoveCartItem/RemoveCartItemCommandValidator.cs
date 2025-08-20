using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.RemoveCartItem
{
    public class RemoveCartItemCommandValidator : IAsyncValidator<RemoveCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public RemoveCartItemCommandValidator( ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result> ValidateAsync( RemoveCartItemCommand request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id корзины не может быть пустым!" );
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
