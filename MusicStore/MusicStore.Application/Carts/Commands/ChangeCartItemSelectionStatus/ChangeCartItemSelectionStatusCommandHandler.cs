using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.ChangeCartItemSelectionStatus
{
    public class ChangeCartItemSelectionStatusCommandHandler : ICommandHandler<ChangeCartItemSelectionStatusCommand, Result<string>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<ChangeCartItemSelectionStatusCommand> _asyncValidator;

        public ChangeCartItemSelectionStatusCommandHandler(
            ICartItemRepository cartItemRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<ChangeCartItemSelectionStatusCommand> asyncValidator )
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( ChangeCartItemSelectionStatusCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                CartItem cartItem = await _cartItemRepository.GetByIdOrDefaultAsync( request.CartItemId );
                cartItem.ChangeSelectionStatus();
                await _unitOfWork.CommitAsync();
                return Result<string>.Success( "Статус успешно изменен!" );
            }
            catch ( Exception ex )
            {
                return Result<string>.Failure( ex.Message );
            }
        }
    }
}
