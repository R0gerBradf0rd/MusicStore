using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.RemoveProductTag
{
    public class RemoveProductTagCommand : ICommand<Result<ProductTag>>
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public RemoveProductTagCommand( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
