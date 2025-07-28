using MediatR;

namespace MusicStore.Application.Interfaces
{
    public interface IQuery<TQueryRequest> : IRequest<TQueryRequest>
    {
    }
}
