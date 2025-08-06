using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToShipping
{
    public class ChangeStatusToShippingCommandHandler : ICommandHandler<ChangeStatusToShippingCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<ChangeStatusToShippingCommand> _asyncValidator;

        public ChangeStatusToShippingCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<ChangeStatusToShippingCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result> Handle( ChangeStatusToShippingCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );
                order.Shipping();
                await _asyncValidator.ValidateAsync( request );
                await _unitOfWork.CommitAsync();
                return Result.Success();
            }
            catch ( Exception ex )
            {
                return Result.Failure( ex.Message );
            }
        }
    }
}
