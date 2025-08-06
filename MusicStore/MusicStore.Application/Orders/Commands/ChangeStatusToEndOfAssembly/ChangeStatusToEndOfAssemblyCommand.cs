using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToEndOfAssembly
{
    public class ChangeStatusToEndOfAssemblyCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public ChangeStatusToEndOfAssemblyCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
