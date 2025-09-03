namespace MusicStore.Presentation.Contracts.Carts.SetCartItemQuantity
{
    public class SetCartItemQuantityRequest
    {
        public Guid Id { get; }

        public int Quantity { get; }

        public SetCartItemQuantityRequest( Guid id, int quantity )
        {
            Id = id;
            Quantity = quantity;
        }
    }
}
