using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Queries.GetCart
{
    public class GetCartQueryValidator : IAsyncValidator<GetCartQuery>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartQueryValidator( ICartRepository cartRepository )
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result> ValidateAsync( GetCartQuery request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isCartExists = await _cartRepository.ContainsAsync( c => c.Id == request.Id );

            if ( !isCartExists )
            {
                return Result.Failure( "Корзины с таким Id не существует!" );
            }

            return Result.Success();
        }
    }
}
