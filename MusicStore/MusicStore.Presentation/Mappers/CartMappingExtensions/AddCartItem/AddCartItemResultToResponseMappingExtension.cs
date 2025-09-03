using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Presentation.Contracts.Carts.AddCartItem;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.AddCartItem
{
    public static class AddCartItemResultToResponseMappingExtension
    {
        public static AddCartItemResponse ToAddCartItemResponse( this Result<CartItem> result )
        {
            return new AddCartItemResponse(
                result.Value.Id,
                result.Value.ProductId,
                result.Value.CartId,
                result.Value.TotalPrice,
                result.Value.Quantity );
        }
    }
}
