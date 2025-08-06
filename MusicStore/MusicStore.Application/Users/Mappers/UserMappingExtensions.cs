using MusicStore.Application.Users.Dtos;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Mappers
{
    public static class UserMappingExtensions
    {
        public static UserDto ToDto( this User user )
        {
            return new UserDto
            (
                user.Name,
                user.Email
            );
        }
    }
}
