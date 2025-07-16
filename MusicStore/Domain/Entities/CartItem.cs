namespace MusicStore.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public int Quantity { get; }
    }
}
