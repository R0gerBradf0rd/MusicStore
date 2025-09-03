using MusicStore.Application.Results;
using MusicStore.Application.Users.Dtos;
using MusicStore.Presentation.Contracts.Users.GetUser;

namespace MusicStore.Presentation.Mappers.UserMappingExtensions.GetUser
{
    public static class GetUserResultToResponseMappingExtension
    {
        public static GetUserResponse ToGetUserResponse( this Result<UserDto> result )
        {
            return new GetUserResponse( result.Value.Name, result.Value.Email );
        }
    }
}
