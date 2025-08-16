using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateOrderCommand> _asyncValidator;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateOrderCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( CreateOrderCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Cart cart = await _cartRepository.GetByIdOrDefaultAsync( request.CartId );
                Order order = new Order( request.UserId, cart.TotalPrice, request.CurrencyCode, request.ShippingAddress, request.CartId );
                List<CartItem> cartItems = cart.CartItems.ToList();

                for ( int i = 0; i < cart.CartItems.Count; i++ )
                {
                    CartItem cartItem = cartItems[ i ];
                    if ( cartItem.IsSelected == CartItemSelectionStatus.Selected )
                    {
                        OrderItem orderItem = new OrderItem( cartItem.ProductId, order.Id, cartItem.Quantity );
                        _orderItemRepository.Add( orderItem );
                        cart.RemoveCartItem( cartItem );
                    }
                }

                _orderRepository.Add( order );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( order.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
