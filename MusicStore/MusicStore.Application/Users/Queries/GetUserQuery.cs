using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Result;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Queries
{
    public class GetUserQuery : IQuery<Result<User>>
    {
        public Guid UserId { get; }

        public GetUserQuery( Guid userId )
        {
            if ( userId == Guid.Empty )
            {
                throw new ArgumentNullException( "Id не может быть пустым!", nameof( userId ) );
            }
            UserId = userId;
        }
    }
}
