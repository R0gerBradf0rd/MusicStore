using MusicStore.Application.Carts.Dtos;
using MusicStore.Application.Carts.Mappers;
using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Queries.GetCart
{
    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, Result<CartDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAsyncValidator<GetCartQuery> _getCartQueryValidator;

        public GetCartQueryHandler( ICartRepository cartRepository, IAsyncValidator<GetCartQuery> asyncValidator )
        {
            _cartRepository = cartRepository;
            _getCartQueryValidator = asyncValidator;
        }

        public async Task<Result<CartDto>> Handle( GetCartQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = await _getCartQueryValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<CartDto>.Failure( validationResult.Error );
            }
            try
            {
                Cart? cart = await _cartRepository.GetByIdOrDefaultAsync( request.Id );

                return Result<CartDto>.Success( cart.ToDto() );
            }
            catch ( Exception ex )
            {
                return Result<CartDto>.Failure( ex.Message );
            }
        }
    }
}
