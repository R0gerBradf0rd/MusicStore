using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.SetStatusToEndOfAssembly
{
    public class SetStatusToEndOfAssemblyCommandHandler : ICommandHandler<SetStatusToEndOfAssemblyCommand, Result>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<SetStatusToEndOfAssemblyCommand> _setStatusToEndOfAssemblyCommandValidator;

        public SetStatusToEndOfAssemblyCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<SetStatusToEndOfAssemblyCommand> setStatusToEndOfAssemblyCommandValidator )
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _setStatusToEndOfAssemblyCommandValidator = setStatusToEndOfAssemblyCommandValidator;
        }

        public async Task<Result> Handle( SetStatusToEndOfAssemblyCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _setStatusToEndOfAssemblyCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );

                order.EndOfAssembly();
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
