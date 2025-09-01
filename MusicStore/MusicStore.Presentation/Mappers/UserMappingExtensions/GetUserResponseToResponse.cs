using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;
using MusicStore.Presentation.Contracts.Users;

namespace MusicStore.Presentation.Mappers.UserMappingExtensions
{
    public static class GetUserResponseToResponse
    {
        public static GetUserResponse ToResponse( this Result<UserDto> result )
        {
            return new GetUserResponse( result.Value.Name, result.Value.Email );
        }
    }
}
