using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.Result;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Users.Commands;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler( IUserRepository userRepository, IUnitOfWork unitOfWork )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle( CreateUserCommand request, CancellationToken cancellationToken )
        {
            var existingUser = await _userRepository.FindAsync( u => u.Email == request.Email );
            if ( existingUser is not null )
            {
                Result<Guid>.Failure( "Пользователь с таким Email уже существует!" );
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
