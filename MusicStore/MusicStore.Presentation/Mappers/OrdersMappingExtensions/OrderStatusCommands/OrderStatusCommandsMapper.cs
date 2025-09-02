using MusicStore.Application.Orders.Commands.SetStatusToArrived;
using MusicStore.Application.Orders.Commands.SetStatusToEndOfAssembly;
using MusicStore.Application.Orders.Commands.SetStatusToShipping;
using MusicStore.Application.Orders.Commands.SetStatusToStartAssembly;

namespace MusicStore.Presentation.Mappers.OrdersMappingExtensions.OrderStatusCommands
{
    public static class OrderStatusCommandsMapper
    {
        public static SetStatusToArrivedCommand ToSetStatusToArrivedCommand( this Guid orderId )
        {
            return new SetStatusToArrivedCommand( orderId );
        }

        public static SetStatusToEndOfAssemblyCommand ToSetStatusToEndOfAssemblyCommand( this Guid orderId )
        {
            return new SetStatusToEndOfAssemblyCommand( orderId );
        }

        public static SetStatusToStartAssemblyCommand ToSetStatusToStartAssemblyCommand( this Guid orderId )
        {
            return new SetStatusToStartAssemblyCommand( orderId );
        }

        public static SetStatusToShippingCommand ToSetStatusToShippingCommand( this Guid orderId )
        {
            return new SetStatusToShippingCommand( orderId );
        }
    }
}
