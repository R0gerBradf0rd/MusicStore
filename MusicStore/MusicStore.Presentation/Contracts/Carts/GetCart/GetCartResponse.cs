using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Presentation.Contracts.Carts.GetCart
{
    public class GetCartResponse
    {
        public decimal TotalPrice { get; }
        public ICollection<CartItem> Items { get; }

        public GetCartResponse( ICollection<CartItem> items, decimal totalPrice )
        {
            Items = items;
            TotalPrice = totalPrice;
        }
    }
}
