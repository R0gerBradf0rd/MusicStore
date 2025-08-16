using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.SetCartItemSelectionStatus
{
    public class SetCartItemSelectionStatusCommandHandler : ICommandHandler<SetCartItemSelectionStatusCommand, Result<string>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<SetCartItemSelectionStatusCommand> _asyncValidator;

        public SetCartItemSelectionStatusCommandHandler(
            ICartItemRepository cartItemRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<SetCartItemSelectionStatusCommand> asyncValidator )
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( SetCartItemSelectionStatusCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                CartItem cartItem = await _cartItemRepository.GetByIdOrDefaultAsync( request.CartItemId );

                cartItem.SetSelectionStatus( request.SelectionStatus );
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
