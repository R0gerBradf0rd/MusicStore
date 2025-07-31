using MusicStore.Application.Users.Dtos;
using MusicStore.Domain.Entities.Users;

namespace MusicStore.Application.Users.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto( this User user )
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
