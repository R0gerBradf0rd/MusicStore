namespace MusicStore.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public int Quantity { get; }
    }
}
