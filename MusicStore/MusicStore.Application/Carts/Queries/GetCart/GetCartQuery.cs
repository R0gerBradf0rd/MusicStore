using MusicStore.Application.Carts.Dtos;
using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Results;

namespace MusicStore.Application.Carts.Queries.GetCart
{
    public class GetCartQuery : IQuery<Result<CartDto>>
    {
        public Guid Id { get; }

        public GetCartQuery( Guid id )
        {
            Id = id;
        }
    }
}
