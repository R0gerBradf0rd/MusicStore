using MusicStore.Application.Users.Commands.CreateUser;
using MusicStore.Presentation.Contracts.Users.CreateUser;

namespace MusicStore.Presentation.Mappers.UserMappingExtensions.CreateUser
{
    public static class CreateUserRequestToCommand
    {
        public static CreateUserCommand ToCreateUserCommand( this CreateUserRequest request )
        {
            return new CreateUserCommand( request.Name, request.Email, request.Role );
        }
    }
}
