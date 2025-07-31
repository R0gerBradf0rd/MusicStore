using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;
using MusicStore.Application.Users.Mappers;
using MusicStore.Application.Users.Repository;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IValidator<GetUserQuery> _validator;

        public GetUserQueryHandler( IUserRepository userRepository, IValidator<GetUserQuery> validator )
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Result<UserDto>> Handle( GetUserQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = _validator.Validate( request );
            if ( validationResult.IsError )
            {
                return Result<UserDto>.Failure( validationResult.Error );
            }
            User? user = await _userRepository.GetByIdOrDefaultAsync( request.UserId );

            if ( user is null )
            {
                return Result<UserDto>.Failure( "Пользователь не найден!" );
            }

            return Result<UserDto>.Success( user.ToDto() );
        }
    }
}
