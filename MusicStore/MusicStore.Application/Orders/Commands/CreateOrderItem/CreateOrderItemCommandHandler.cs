using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : ICommandHandler<CreateOrderItemCommand, Result<Guid>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateOrderItemCommand> _asyncValidator;

        public CreateOrderItemCommandHandler(
            IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository,
            ICartItemRepository cartItemRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateOrderItemCommand> asyncValidator )
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateOrderItemCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.OrderId );
                CartItem cartItem = await _cartItemRepository.FindeAsync( ci => ci.CartId == order.CartId && ci.ProductId == request.ProductId );
                OrderItem orderItem = new OrderItem( request.ProductId, request.OrderId, cartItem.Quantity );

                _orderItemRepository.Add( orderItem );
                await _cartItemRepository.DeleteAsync( cartItem );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( orderItem.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
