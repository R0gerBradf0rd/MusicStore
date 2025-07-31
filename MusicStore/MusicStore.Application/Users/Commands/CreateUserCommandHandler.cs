using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.ResultPattern;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<CreateUserCommand> _asyncValidator;

        public CreateUserCommandHandler( IUserRepository userRepository, IUnitOfWork unitOfWork, IAsyncValidator<CreateUserCommand> asyncValidator )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateUserCommand request, CancellationToken cancellationToken )
        {
            var validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                User user = new( request.Name, request.Email, request.Role );
                await _userRepository.AddAsync( user );
                await _unitOfWork.CommitAsync();
                return Result<Guid>.Success( user.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
