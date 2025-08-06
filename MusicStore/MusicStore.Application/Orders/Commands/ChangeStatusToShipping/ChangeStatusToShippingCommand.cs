using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToShipping
{
    public class ChangeStatusToShippingCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public ChangeStatusToShippingCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
