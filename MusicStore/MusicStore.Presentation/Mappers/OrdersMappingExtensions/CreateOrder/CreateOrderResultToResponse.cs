using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Orders.CreateOrder;

namespace MusicStore.Presentation.Mappers.OrdersMappingExtensions.CreateOrder
{
    public static class CreateOrderResultToResponse
    {
        public static CreateOrderResponse ToCreateOrderResponse( this Result<Guid> result )
        {
            return new CreateOrderResponse( result.Value );
        }
    }
}
