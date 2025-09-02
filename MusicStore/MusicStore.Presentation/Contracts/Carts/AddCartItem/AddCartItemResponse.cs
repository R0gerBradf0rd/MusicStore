namespace MusicStore.Presentation.Contracts.Carts.AddCartItem
{
    public class AddCartItemResponse
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public Guid CartId { get; }

        public decimal TotalPrice { get; }

        public int Quantity { get; }

        public AddCartItemResponse(
            Guid id,
            Guid productId,
            Guid cartId,
            decimal totalPrice,
            int quantity )
        {
            Id = id;
            ProductId = productId;
            CartId = cartId;
            TotalPrice = totalPrice;
            Quantity = quantity;
        }
    }
}
