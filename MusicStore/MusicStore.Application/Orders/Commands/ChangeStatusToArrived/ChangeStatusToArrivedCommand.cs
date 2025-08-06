using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToArrived
{
    public class ChangeStatusToArrivedCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public ChangeStatusToArrivedCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
