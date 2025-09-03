using MusicStore.Application.Orders.Dtos;
using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Orders.GetOrder;

namespace MusicStore.Presentation.Mappers.OrdersMappingExtensions.GetOrder
{
    public static class GetOrderResultToResponseMappingExtension
    {
        public static GetOrderResponse ToGetOrderResponse( this Result<OrderDto> result )
        {
            var dto = result.Value;
            return new GetOrderResponse(
                dto.Status.ToString(),
                dto.TotalPrice,
                dto.TotalPriceCurrencyCode,
                dto.OrderNumber,
                dto.ShippingAddress );
        }
    }
}
