using MusicStore.Application.Carts.Queries.GetCart;
using MusicStore.Presentation.Contracts.Carts.GetCart;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.GetCart
{
    public static class GetCartRequestToQueryMappingExtension
    {
        public static GetCartQuery ToGetCartQuery( this GetCartRequest request )
        {
            return new GetCartQuery( request.Id );
        }
    }
}
