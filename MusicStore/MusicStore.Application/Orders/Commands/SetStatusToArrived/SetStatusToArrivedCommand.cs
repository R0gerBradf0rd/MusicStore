using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.SetStatusToArrived
{
    public class SetStatusToArrivedCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public SetStatusToArrivedCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
