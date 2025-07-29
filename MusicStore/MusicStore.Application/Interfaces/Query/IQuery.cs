using MediatR;

namespace MusicStore.Application.Interfaces.Query
{
    public interface IQuery<TQueryRequest> : IRequest<TQueryRequest>
    {
    }
}
