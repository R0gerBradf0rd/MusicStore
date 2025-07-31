using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.ResultPattern;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Result<User>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IValidator<GetUserQuery> _validator;

        public GetUserQueryHandler( IUserRepository userRepository, IValidator<GetUserQuery> validator )
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Result<User>> Handle( GetUserQuery request, CancellationToken cancellationToken )
        {
            var validationResult = _validator.Validate( request );
            if ( validationResult.IsError )
            {
                return Result<User>.Failure( validationResult.Error );
            }
            User? user = await _userRepository.GetByIdAsync( request.UserId );

            if ( user is null )
            {
                return Result<User>.Failure( "Пользователь не найден!" );
            }

            return Result<User>.Success( user );
        }
    }
}
