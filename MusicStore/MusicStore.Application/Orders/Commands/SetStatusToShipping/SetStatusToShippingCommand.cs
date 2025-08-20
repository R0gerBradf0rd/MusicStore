using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.SetStatusToShipping
{
    public class SetStatusToShippingCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public SetStatusToShippingCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
