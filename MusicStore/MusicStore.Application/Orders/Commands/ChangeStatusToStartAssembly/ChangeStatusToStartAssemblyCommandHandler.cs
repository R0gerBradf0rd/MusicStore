using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.ChangeStatusToStartAssembly
{
    public class ChangeStatusToStartAssemblyCommandHandler : ICommandHandler<ChangeStatusToStartAssemblyCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<ChangeStatusToStartAssemblyCommand> _asyncValidator;

        public ChangeStatusToStartAssemblyCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<ChangeStatusToStartAssemblyCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result> Handle( ChangeStatusToStartAssemblyCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );
                order.StartAssembly();
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
