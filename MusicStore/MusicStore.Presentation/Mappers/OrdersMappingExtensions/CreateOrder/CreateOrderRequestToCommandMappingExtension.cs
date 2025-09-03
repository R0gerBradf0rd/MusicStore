using MusicStore.Application.Orders.Commands.CreateOrder;
using MusicStore.Presentation.Contracts.Orders.CreateOrder;

namespace MusicStore.Presentation.Mappers.OrdersMappingExtensions.CreateOrder
{
    public static class CreateOrderRequestToCommandMappingExtension
    {
        public static CreateOrderCommand ToCreateOrderCommand( this CreateOrderRequest request )
        {
            return new CreateOrderCommand(
                request.UserId,
                request.CartId,
                request.ShippingAddress,
                request.CurrencyCode );
        }
    }
}
