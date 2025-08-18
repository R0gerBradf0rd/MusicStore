using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.RemoveCartItem
{
    public class RemoveCartItemCommandHandler : ICommandHandler<RemoveCartItemCommand, Result<CartItem>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IAsyncValidator<RemoveCartItemCommand> _asyncValidator;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCartItemCommandHandler(
            ICartRepository cartRepository,
            IAsyncValidator<RemoveCartItemCommand> validator,
            IUnitOfWork unitOfWork,
            ICartItemRepository cartItemRepository )
        {
            _cartRepository = cartRepository;
            _asyncValidator = validator;
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result<CartItem>> Handle( RemoveCartItemCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<CartItem>.Failure( validationResult.Error );
            }
            try
            {
                CartItem cartItem = await _cartItemRepository.GetByIdOrDefaultAsync( request.Id );
                Cart? cart = await _cartRepository.GetByIdOrDefaultAsync( cartItem.CartId );

                cart.RemoveItem( cartItem );
                await _unitOfWork.CommitAsync();

                return Result<CartItem>.Success( cartItem );
            }
            catch ( Exception ex )
            {
                return Result<CartItem>.Failure( ex.Message );
            }
        }
    }
}
