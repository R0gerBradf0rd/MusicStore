using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.ResultPattern;

namespace MusicStore.Application.Users.Commands
{
    public class CreateUserCommand : ICommand<Result<Guid>>
    {
        public string Name { get; }

        public string Email { get; }

        public string Role { get; }

        public CreateUserCommand( string name, string email, string role )
        {
            Name = name;
            Email = email;
            Role = role;
        }
    }
}
