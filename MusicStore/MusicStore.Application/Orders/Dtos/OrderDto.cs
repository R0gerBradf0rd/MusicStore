using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Dtos
{
    public class OrderDto
    {
        public OrderStatus Status { get; }

        public decimal TotalPrice { get; }

        public string TotalPriceCurrencyCode { get; }

        public Guid OrderNumber { get; }

        public string ShippingAddress { get; }

        public OrderDto(
            OrderStatus status,
            decimal totalPrice,
            string totalPriceCurrencyCode,
            Guid orderNumber,
            string shippingAddress )
        {
            Status = status;
            TotalPrice = totalPrice;
            TotalPriceCurrencyCode = totalPriceCurrencyCode;
            OrderNumber = orderNumber;
            ShippingAddress = shippingAddress;
        }
    }
}
