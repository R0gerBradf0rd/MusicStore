using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Products.Dtos;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IQuery<Result<ProductDto>>
    {
        public Guid Id { get; }

        public GetProductQuery( Guid id )
        {
            Id = id;
        }
    }
}
