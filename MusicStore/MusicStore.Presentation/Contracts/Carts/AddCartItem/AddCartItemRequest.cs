namespace MusicStore.Presentation.Contracts.Carts.AddCartItem
{
    public class AddCartItemRequest
    {
        public Guid CartId { get; }

        public Guid ProductId { get; }

        public AddCartItemRequest( Guid cartId, Guid productId )
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
