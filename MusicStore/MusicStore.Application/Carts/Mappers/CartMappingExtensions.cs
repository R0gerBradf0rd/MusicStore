using MusicStore.Application.Carts.Dtos;
using MusicStore.Domain.Entities.Carts;

namespace MusicStore.Application.Carts.Mappers
{
    public static class CartMappingExtensions
    {
        public static CartDto ToDto( this Cart cart )
        {
            return new CartDto
            (
                cart.CartItems,
                cart.TotalPrice
            );
        }
    }
}
