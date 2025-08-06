using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToArrived
{
    public class ChangeStatusToArrivedCommanValidator : IAsyncValidator<ChangeStatusToArrivedCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusToArrivedCommanValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( ChangeStatusToArrivedCommand request )
        {
            if ( request.OrderId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

            if ( order.Status != OrderStatus.Shipped )
            {
                return Result.Failure( "Невозможно перейти в этот статус! Предыдущий статус должен быть Shipped!" );
            }

            return Result.Success();
        }
    }
}
