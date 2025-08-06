using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToStartAssembly
{
    public class ChangeStatusToStartAssemblyCommandValidator : IAsyncValidator<ChangeStatusToStartAssemblyCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusToStartAssemblyCommandValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( ChangeStatusToStartAssemblyCommand request )
        {
            if ( request.OrderId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

            if ( order.Status != OrderStatus.Created )
            {
                return Result.Failure( "Невозможно перейти в этот статус. Предыдущий статус должен быть Created" );
            }

            return Result.Success();
        }
    }
}
