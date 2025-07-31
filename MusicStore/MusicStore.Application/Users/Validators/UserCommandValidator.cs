using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.ResultPattern;
using MusicStore.Application.Users.Commands;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Validators
{
    public class UserCommandValidator : IAsyncValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandValidator( IUserRepository userRepository )
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

            User? user = await _userRepository.FindAsync( user => user.Email == request.Email );

            if ( user is not null )
            {
                return Result.Failure( "Пользователь с таким Email уже существует!" );
            }

            return Result.Success();
        }
    }
}
