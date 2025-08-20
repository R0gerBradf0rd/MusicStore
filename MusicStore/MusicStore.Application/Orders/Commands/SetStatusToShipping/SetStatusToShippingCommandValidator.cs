using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToShipping
{
    public class SetStatusToShippingCommandValidator : IAsyncValidator<SetStatusToShippingCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public SetStatusToShippingCommandValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( SetStatusToShippingCommand request )
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
