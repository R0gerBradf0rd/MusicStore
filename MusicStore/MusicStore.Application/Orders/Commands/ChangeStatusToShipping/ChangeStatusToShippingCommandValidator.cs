using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToShipping
{
    public class ChangeStatusToShippingCommandValidator : IAsyncValidator<ChangeStatusToShippingCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusToShippingCommandValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( ChangeStatusToShippingCommand request )
        {
            if ( request.OrderId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

            if ( order.Status != OrderStatus.ReadyToShip )
            {
                return Result.Failure( "Невозможно перейти в этот статус. Предыдущий статус должен быть ReadyToShip." );
            }

            return Result.Success();
        }
    }
}
