using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.ResultPattern;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

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

            bool isUserExist = await _userRepository.ContainsAsync( user => user.Email == request.Email );

            if ( isUserExist )
            {
                return Result.Failure( "Пользователь с таким Email уже существует!" );
            }

            return Result.Success();
        }
    }
}
