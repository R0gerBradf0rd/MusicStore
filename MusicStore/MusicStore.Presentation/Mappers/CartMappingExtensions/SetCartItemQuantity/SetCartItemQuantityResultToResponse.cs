using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Carts.SetCartItemQuantity;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemQuantity
{
    public static class SetCartItemQuantityResultToResponse
    {
        public static SetCartItemQuantityResponse ToSetCartItemQuantityResponse( this Result<string> result )
        {
            return new SetCartItemQuantityResponse( result.Value );
        }
    }
}
