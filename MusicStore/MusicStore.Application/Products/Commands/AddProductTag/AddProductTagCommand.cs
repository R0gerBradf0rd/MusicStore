using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.AddProductTag
{
    public class AddProductTagCommand : ICommand<Result<ProductTag>>
    {
        public Guid TagId { get; }

        public Guid ProductId { get; }

        public AddProductTagCommand( Guid tagId, Guid productId )
        {
            TagId = tagId;
            ProductId = productId;
        }
    }
}
