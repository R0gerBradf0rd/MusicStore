using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToStartAssembly
{
    public class SetStatusToStartAssemblyCommandHandler : ICommandHandler<SetStatusToStartAssemblyCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<SetStatusToStartAssemblyCommand> _setStatusToStartAssemblyCommandValidator;

        public SetStatusToStartAssemblyCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<SetStatusToStartAssemblyCommand> setStatusToStartAssemblyCommandValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _setStatusToStartAssemblyCommandValidator = setStatusToStartAssemblyCommandValidator;
        }

        public async Task<Result> Handle( SetStatusToStartAssemblyCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _setStatusToStartAssemblyCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

                order.StartAssembly();
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
