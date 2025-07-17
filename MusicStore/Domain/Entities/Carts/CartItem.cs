namespace MusicStore.Domain.Entities.Carts
{
    public class CartItem
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public Guid CartId { get; }

        public int Quantity { get; }
    }
}
// IncreaseQuantityByOne
// DecreaseQuantityByOne