using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Orders.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandмValidator : IAsyncValidator<CreateOrderItemCommand>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        private readonly IOrderRepository _orderRepository;

        private readonly IProductRepository _productRepository;

        public CreateOrderItemCommandмValidator(
            IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository )
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Result> ValidateAsync( CreateOrderItemCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.OrderId == Guid.Empty )
            {
                return Result.Failure( "Id заказа не может быть пустым!" );
            }

            bool isOrderExist = await _orderRepository.ContainsAsync( o => o.Id == request.OrderId );

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );

            bool isOrderItemAlreadyExist = await _orderItemRepository.ContainsAsync( oi => oi.OrderId == request.OrderId && oi.ProductId == request.ProductId );

            if ( !isOrderExist )
            {
                return Result.Failure( "Данного заказа несуществует!" );
            }
            if ( !isProductExist )
            {
                return Result.Failure( "Данного продукта несуществует!" );
            }
            if ( isOrderItemAlreadyExist )
            {
                return Result.Failure( "Данный элемент заказа уже существует!" );
            }

            return Result.Success();
        }
    }
}
