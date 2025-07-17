namespace MusicStore.Domain.Entities.Carts
{
    public class Cart
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public ICollection<CartItem> Items { get; }

        public void Clear()
        {
            Items.Clear();
        }

        public void Add( CartItem cartItem )
        {
            Items.Add( cartItem );
        }
    }
}
