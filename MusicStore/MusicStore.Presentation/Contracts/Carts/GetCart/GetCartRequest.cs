namespace MusicStore.Presentation.Contracts.Carts.GetCart
{
    public class GetCartRequest
    {
        public Guid Id { get; }

        public GetCartRequest( Guid id )
        {
            Id = id;
        }
    }
}
