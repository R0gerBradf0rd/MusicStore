using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.ResultPattern;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IQuery<Result<User>>
    {
        public Guid UserId { get; }

        public GetUserQuery( Guid userId )
        {
            UserId = userId;
        }
    }
}
