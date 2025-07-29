using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.Result;

namespace MusicStore.Application.Users.Commands
{
    public class CreateUserCommand : ICommand<Result<Guid>>
    {
        public string Name { get; }

        public string Email { get; }

        public string Role { get; }

        public CreateUserCommand( string name, string email, string role )
        {
            if ( string.IsNullOrWhiteSpace( name ) )
            {
                throw new ArgumentNullException( "Имя не может быть пустым!", nameof( name ) );
            }
            if ( string.IsNullOrWhiteSpace( email ) )
            {
                throw new ArgumentNullException( "Email не может быть пустым!", nameof( email ) );
            }
            if ( string.IsNullOrWhiteSpace( role ) )
            {
                throw new ArgumentNullException( "Роль не может быть пустой!", nameof( role ) );
            }
            Name = name;
            Email = email;
            Role = role;
        }
    }
}
