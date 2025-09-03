using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Dtos
{
    public class CartDto
    {
        public decimal TotalPrice { get; }

        public ICollection<CartItem> Items { get; }

        public CartDto( ICollection<CartItem> items, decimal totalPrice )
        {
            Items = items;
            TotalPrice = totalPrice;
        }
    }
}
