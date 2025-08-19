using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToArrived
{
    public class SetStatusToArrivedCommandValidator : IAsyncValidator<SetStatusToArrivedCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public SetStatusToArrivedCommandValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( SetStatusToArrivedCommand request )
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
