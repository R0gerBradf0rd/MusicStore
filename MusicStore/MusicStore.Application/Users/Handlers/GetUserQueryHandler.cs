using MediatR;
using MusicStore.Application.Interfaces.Result;
using MusicStore.Application.Users.Queries;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Handle( GetUserQuery request, CancellationToken cancellationToken )
        {
            User user = await _userRepository.GetByIdAsync( request.UserId );

            if ( user is null )
            {
                return Result<User>.Failure( "Пользователь не найден!" );
            }

            return Result<User>.Success( user );
        }
    }
}
