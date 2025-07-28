using MediatR;

namespace MusicStore.Application.Interfaces
{
    public interface ICommand<TCommandResult> : IRequest<TCommandResult>
    {
    }
}
