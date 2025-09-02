using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Users.CreateUser;

namespace MusicStore.Presentation.Mappers.UserMappingExtensions.CreateUser
{
    public static class CreateUserResultToResponse
    {
        public static CreateUserResponse ToCreateUserResponse( this Result<Guid> result )
        {
            return new CreateUserResponse( result.Value );
        }
    }
}
