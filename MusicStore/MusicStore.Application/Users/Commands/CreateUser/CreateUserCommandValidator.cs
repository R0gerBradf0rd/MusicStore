using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Repositories;

namespace MusicStore.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : IAsyncValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<Result> ValidateAsync( CreateUserCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Name ) )
            {
                return Result.Failure( "Имя пользователя не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.Email ) )
            {
                return Result.Failure( "Email пользователя не может быть пустым!" );
            }
            if ( string.IsNullOrWhiteSpace( request.Role ) )
            {
                return Result.Failure( "Роль пользователя не может быть пустой!" );
            }

            bool isUserExists = await _userRepository.ContainsAsync( user => user.Email == request.Email );

            if ( isUserExists )
            {
                return Result.Failure( "Пользователь с таким Email уже существует!" );
            }

            return Result.Success();
        }
    }
}
