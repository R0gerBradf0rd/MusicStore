using MediatR;
using MusicStore.Application.Interfaces;

namespace MusicStore.Application.Commands
{
    public class CreateUserCommand : ICommand<Guid>
    {
        public string Name { get; }

        public string Email { get; }

        public string Role { get; }
    }
}
