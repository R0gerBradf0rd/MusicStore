using MusicStore.Application.Orders.Dtos;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Mappers
{
    public static class OrderMappingExtensions
    {
        public static OrderDto ToDto( this Order order )
        {
            return new OrderDto
            (
                order.Status,
                order.TotalPrice,
                order.TotalPriceCurrencyCode,
                order.OrderNumber,
                order.ShippingAddress
            );
        }
    }
}
