namespace MusicStore.Domain.Entities.Orders
{
    public class Odrer
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public OrderStatus Status { get; private set; }

        public DateTime CreationDate { get; }

        public DateTime AssemblyProcessStartDate { get; private set; }

        public decimal TotalPrice { get; }

        public string TotalPriceCurrencyCode { get; }

        public string OrderNumber { get; } // создать сервис

        public string ShippingAssress { get; }

        public Guid CartId { get; }

        public Odrer( Guid userId, decimal totalPrice, string totalPriceCurrencyCode, string shippingAssress, Guid cartId )
        {
            if ( totalPrice <= 0 )
            {
                throw new ArgumentException( "Сумма заказа должна быть больше нуля!" );
            }
            UserId = userId;
            TotalPrice = totalPrice;
            TotalPriceCurrencyCode = totalPriceCurrencyCode;
            ShippingAssress = shippingAssress;
            CartId = cartId;
            Status = OrderStatus.Created;
            CreationDate = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        public void StartAssembly()
        {
            Status = OrderStatus.AssemblyProccess;
            AssemblyProcessStartDate = DateTime.UtcNow;
        }
    }
}
// CalculateTotalPrice
// SetTheOrderNumber
// SetTheShippingAddress
// SetTheOrderStatus