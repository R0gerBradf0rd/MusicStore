using MediatR;

namespace MusicStore.Application.Interfaces
{
    public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
    }
}
