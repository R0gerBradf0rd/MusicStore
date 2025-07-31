using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.ResultPattern;
using MusicStore.Application.Users.Queries;

namespace MusicStore.Application.Users.Validators
{
    public class UserQueryValidator : IValidator<GetUserQuery>
    {
        public UserQueryValidator()
        {
        }

        public Result Validate( GetUserQuery request )
        {
            if ( request.UserId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым" );
            }
            return Result.Success();
        }
    }
}
