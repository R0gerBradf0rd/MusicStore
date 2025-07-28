using MediatR;

namespace MusicStore.Application.Interfaces
{
    public interface ICommandHandler<TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
        where TCommand : ICommand<TCommandResult>
    {

    }
}
