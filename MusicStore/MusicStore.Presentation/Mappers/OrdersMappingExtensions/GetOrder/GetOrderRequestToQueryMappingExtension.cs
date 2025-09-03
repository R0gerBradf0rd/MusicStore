using MusicStore.Application.Orders.Queries.GetOrder;

namespace MusicStore.Presentation.Mappers.OrdersMappingExtensions.GetOrder
{
    public static class GetOrderRequestToQueryMappingExtension
    {
        public static GetOrderQuery ToGetOrderQuery( this Guid orderId )
        {
            return new GetOrderQuery( orderId );
        }
    }
}
