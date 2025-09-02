namespace MusicStore.Presentation.Contracts.Orders.CreateOrder
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; }

        public CreateOrderResponse( Guid orderId )
        {
            OrderId = orderId;
        }
    }
}
