using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryValidator : IAsyncValidator<GetOrderQuery>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( GetOrderQuery request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может бытьп пустым!" );
            }

            bool isOrderExists = await _orderRepository.ContainsAsync( o => o.Id == request.Id );

            if ( !isOrderExists )
            {
                return Result.Failure( "Данного заказа несуществует!" );
            }

            return Result.Success();
        }
    }
}
