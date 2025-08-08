using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.CreateUserCart
{
    public class CreateUserCartCommandValidator : IAsyncValidator<CreateUserCartCommand>
    {
        private readonly ICartRepository _cartRepository;

        public CreateUserCartCommandValidator( ICartRepository cartRepository )
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> ValidateAsync( CreateUserCartCommand request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id пользователя не может быть пустым!" );
            }

            bool isCartExitst = await _cartRepository.ContainsAsync( c => c.UserId == request.UserId );

            if ( isCartExitst )
            {
                return Result.Failure( "У этого пользователя уже существует корзина!" );
            }
            return Result.Success();
        }
    }
}
