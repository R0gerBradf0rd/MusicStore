using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : ICommand<Result<Guid>>
    {
        public Guid ProductId { get; }

        public Guid OrderId { get; }

        public CreateOrderItemCommand( Guid productId, Guid orderId )
        {
            ProductId = productId;
            OrderId = orderId;
        }
    }
}
