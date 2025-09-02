using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Presentation.Contracts.Carts.RemoveCartItem;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.RemoveCartItem
{
    public static class RemoveCartItemResultToResponse
    {
        public static RemoveCartItemResponse ToRemoveCartItemResponse( this Result<CartItem> result )
        {
            return new RemoveCartItemResponse(
                result.Value.Id,
                result.Value.ProductId,
                result.Value.CartId,
                result.Value.TotalPrice,
                result.Value.Quantity );
        }
    }
}
