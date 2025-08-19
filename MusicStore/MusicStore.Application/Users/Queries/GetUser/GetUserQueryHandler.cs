using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;
using MusicStore.Application.Users.Mappers;
using MusicStore.Application.Users.Repositories;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAsyncValidator<GetUserQuery> _getUserQueryValidator;

        public GetUserQueryHandler( IUserRepository userRepository, IAsyncValidator<GetUserQuery> validator )
        {
            _userRepository = userRepository;
            _getUserQueryValidator = validator;
        }

        public async Task<Result<UserDto>> Handle( GetUserQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = await _getUserQueryValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<UserDto>.Failure( validationResult.Error );
            }
            try
            {
                User? user = await _userRepository.GetByIdOrDefaultAsync( request.UserId );

                return Result<UserDto>.Success( user.ToDto() );
            }
            catch ( Exception ex )
            {
                return Result<UserDto>.Failure( ex.Message );
            }
        }
    }
}
