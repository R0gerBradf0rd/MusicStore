using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Orders.Dtos;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Queries.GetOrder
{
    public class GetOrderQuery : IQuery<Result<OrderDto>>
    {
        public Guid Id { get; }

        public GetOrderQuery( Guid id )
        {
            Id = id;
        }
    }
}
