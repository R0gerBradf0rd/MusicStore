namespace MusicStore.Presentation.Contracts.Orders.GetOrder
{
    public class GetOrderResponse
    {
        public string Status { get; }

        public decimal TotalPrice { get; }

        public string TotalPriceCurrencyCode { get; }

        public Guid OrderNumber { get; }

        public string ShippingAddress { get; }

        public GetOrderResponse(
            string status,
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
