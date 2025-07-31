using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;

namespace MusicStore.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IQuery<Result<UserDto>>
    {
        public Guid UserId { get; }

        public GetUserQuery( Guid userId )
        {
            UserId = userId;
        }
    }
}
