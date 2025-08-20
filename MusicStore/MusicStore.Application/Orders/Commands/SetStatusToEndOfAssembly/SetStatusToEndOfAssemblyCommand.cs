using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.SetStatusToEndOfAssembly
{
    public class SetStatusToEndOfAssemblyCommand : ICommand<Result>
    {
        public Guid OrderId { get; }

        public SetStatusToEndOfAssemblyCommand( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
