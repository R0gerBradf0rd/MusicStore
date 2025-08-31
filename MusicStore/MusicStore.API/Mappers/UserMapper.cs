using MusicStore.Application.Results;
using MusicStore.Application.Users.Commands.CreateUser;
using MusicStore.Application.Users.Dtos;
using MusicStore.Presentation.Contracts.Users;

namespace MusicStore.Presentation.Mappers
{
    public static class UserMapper
    {
        public static CreateUserCommand ToCommand( this CreateUserRequest request )
        {
            return new CreateUserCommand( request.Name, request.Email, request.Role );
        }

        public static CreateUserResponse ToResponse( this Result<Guid> result )
        {
            return new CreateUserResponse( result.Value );
        }

        public static GetUserResponse ToResponse( this Result<UserDto> result )
        {
            return new GetUserResponse( result.Value.Name, result.Value.Email );
        }
    }
}
