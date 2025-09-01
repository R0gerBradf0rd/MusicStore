using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Users;

namespace MusicStore.Presentation.Mappers.UserMappingExtensions
{
    public static class CreateUserResponseToResponse
    {
        public static CreateUserResponse ToResponse( this Result<Guid> result )
        {
            return new CreateUserResponse( result.Value );
        }
    }
}
