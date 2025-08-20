using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.SetStatusToStartAssembly
{
    public class SetStatusToStartAssemblyCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public SetStatusToStartAssemblyCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
