using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Mappers
{
    public static class OrderItemMappingExtensions
    {
        public static OrderItem ToOrderItem( this CartItem item, Guid orderId )
        {
            return new OrderItem
            (
                item.ProductId,
                orderId,
                item.Quantity
            );
        }
    }
}
