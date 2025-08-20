using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Repositories;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQueryValidator : IAsyncValidator<GetUserQuery>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryValidator( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<Result> ValidateAsync( GetUserQuery request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым" );
            }

            bool isUserExists = await _userRepository.ContainsAsync( u => u.Id == request.UserId );

            if ( !isUserExists )
            {
                return Result.Failure( "Пользователя с таким Id несуществует!" );
            }
            return Result.Success();
        }
    }
}
