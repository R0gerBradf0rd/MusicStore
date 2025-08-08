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
                Cart? cart = await _cartRepository.GetByIdOrDefaultAsync( request.CartId );
                CartItem cartItem = new CartItem( request.ProductId, request.CartId );

                cart.RemoveCartItem( cartItem );
                cart.CalculateTotalPrice();
                await _cartItemRepository.DeleteAsync( cartItem );
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
