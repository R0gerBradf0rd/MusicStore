using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Commands.CreateUserCart
{
    public class CreateUserCartCommandHandler : ICommandHandler<CreateUserCartCommand, Result<Guid>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateUserCartCommand> _asyncValidator;

        public CreateUserCartCommandHandler(
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateUserCartCommand> asyncValidator )
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateUserCartCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Cart cart = new Cart( request.UserId );

                _cartRepository.Add( cart );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( cart.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
