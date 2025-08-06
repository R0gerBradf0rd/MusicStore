using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToStartAssembly
{
    public class ChangeStatusToStartAssemblyCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public ChangeStatusToStartAssemblyCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
