using MediatR;
using MusicStore.Application.Interfaces;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Queries
{
    public class GetUserByIdQuery : IQuery<User>
    {
        public Guid Id { get; set; }
    }
}
