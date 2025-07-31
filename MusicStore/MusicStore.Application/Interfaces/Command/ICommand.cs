using MediatR;

namespace MusicStore.Application.Interfaces.Command
{
    public interface ICommand<TCommandResult> : IRequest<TCommandResult>
    {
    }
}
