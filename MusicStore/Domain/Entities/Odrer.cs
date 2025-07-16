namespace MusicStore.Domain.Entities
{
    public class Odrer
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public string Status { get; }

        public DateOnly Date { get; }

        public double TotalPrice { get; }

        public int OrderNumber { get; }

        public string ShippingAssress { get; }

        public Guid OrderItemId { get; }

        public Guid CartId { get; }
    }
}
