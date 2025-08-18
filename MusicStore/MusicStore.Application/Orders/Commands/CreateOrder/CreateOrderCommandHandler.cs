using MusicStore.Application.Carts.Repositories;
using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Mappers;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Applicatuion.Warehouses.Repositories;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Domain.Entities.Orders;
using MusicStore.Domain.Entities.Products;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductWarehouseRepository _productWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateOrderCommand> _asyncValidator;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            IProductWarehouseRepository productWarehouseRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateOrderCommand> asyncValidator )
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _productWarehouseRepository = productWarehouseRepository;
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

                foreach ( CartItem cartItem in cartItems )
                {
                    if ( cartItem.IsSelected == CartItemSelectionStatus.Selected )
                    {
                        _orderItemRepository.Add( cartItem.ToOrderItem( order.Id ) );
                        ProductWarehouse productWarehouse = await _productWarehouseRepository.FindeAsync( pw => pw.ProductId == cartItem.ProductId );
                        productWarehouse.ReserveProductInWarehouse();
                        cart.RemoveItem( cartItem );
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
