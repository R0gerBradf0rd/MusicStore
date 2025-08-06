using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Commands.CreateUserCart
{
    public class CreateUserCartCommand : ICommand<Result<Guid>>
    {
        public Guid UserId { get; }

        public CreateUserCartCommand( Guid userId )
        {
            UserId = userId;
        }
    }
}
