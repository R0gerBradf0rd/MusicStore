using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToArrived
{
    public class ChangeStatusToArrivedCommandHandler : ICommandHandler<ChangeStatusToArrivedCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<ChangeStatusToArrivedCommand> _asyncValidator;

        public ChangeStatusToArrivedCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<ChangeStatusToArrivedCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result> Handle( ChangeStatusToArrivedCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );
                order.Arrived();
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
