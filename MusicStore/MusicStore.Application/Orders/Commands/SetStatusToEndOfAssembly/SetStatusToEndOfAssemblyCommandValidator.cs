using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToEndOfAssembly
{
    public class SetStatusToEndOfAssemblyCommandValidator : IAsyncValidator<SetStatusToEndOfAssemblyCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public SetStatusToEndOfAssemblyCommandValidator( IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> ValidateAsync( SetStatusToEndOfAssemblyCommand request )
        {
            if ( request.OrderId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

            if ( order.Status != OrderStatus.AssemblyProcess )
            {
                return Result.Failure( "Невозможно перейти в этот статус. Предыдущий статус должен быть AssemblyProcess." );
            }

            return Result.Success();
        }
    }
}
