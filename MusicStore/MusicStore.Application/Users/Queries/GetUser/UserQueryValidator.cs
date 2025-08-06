using System.Threading.Tasks;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Repositories;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class UserQueryValidator : IAsyncValidator<GetUserQuery>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryValidator( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<Result> ValidateAsync( GetUserQuery request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым" );
            }

            bool isUserExist = await _userRepository.ContainsAsync( u => u.Id == request.UserId );

            if ( !isUserExist )
            {
                return Result.Failure( "Пользователя с таким Id несуществует!" );
            }
            return Result.Success();
        }
    }
}
