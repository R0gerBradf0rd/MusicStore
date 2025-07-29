using MediatR;

namespace MusicStore.Application.Interfaces.Command
{
    public interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
        where TCommand : ICommand<TCommandResult>
    {

    }
}
