namespace MusicStore.Presentation.Contracts.Carts.RemoveCartItem
{
    public class RemoveCartItemRequest
    {
        public Guid Id { get; }

        public RemoveCartItemRequest( Guid id )
        {
            Id = id;
        }
    }
}
