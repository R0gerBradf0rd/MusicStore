using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToArrived
{
    public class SetStatusToArrivedCommandHandler : ICommandHandler<SetStatusToArrivedCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<SetStatusToArrivedCommand> _setStatusToArrivedCommandValidator;

        public SetStatusToArrivedCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<SetStatusToArrivedCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _setStatusToArrivedCommandValidator = asyncValidator;
        }

        public async Task<Result> Handle( SetStatusToArrivedCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _setStatusToArrivedCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

                order.Arrived();
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
