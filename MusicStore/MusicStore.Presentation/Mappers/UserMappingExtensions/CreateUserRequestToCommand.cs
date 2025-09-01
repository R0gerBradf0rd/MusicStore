using MusicStore.Application.Users.Commands.CreateUser;
using MusicStore.Presentation.Contracts.Users;

namespace MusicStore.Presentation.UserMappingExtensions
{
    public static class CreateUserRequestToCommand
    {
        public static CreateUserCommand ToCommand( this CreateUserRequest request )
        {
            return new CreateUserCommand( request.Name, request.Email, request.Role );
        }
    }
}
