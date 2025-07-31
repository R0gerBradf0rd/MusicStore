using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class UserQueryValidator : IValidator<GetUserQuery>
    {
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
