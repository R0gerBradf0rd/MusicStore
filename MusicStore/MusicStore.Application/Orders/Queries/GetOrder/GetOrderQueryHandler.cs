using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Orders.Dtos;
using MusicStore.Application.Orders.Mappers;
using MusicStore.Application.Orders.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Orders;

namespace MusicStore.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAsyncValidator<GetOrderQuery> _getOrderQueryValidator;

        public GetOrderQueryHandler(
            IOrderRepository orderRepository,
            IAsyncValidator<GetOrderQuery> getOrderQueryValidator )
        {
            _orderRepository = orderRepository;
            _getOrderQueryValidator = getOrderQueryValidator;
        }

        public async Task<Result<OrderDto>> Handle( GetOrderQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = await _getOrderQueryValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<OrderDto>.Failure( validationResult.Error );
            }
            try
            {
                Order order = await _orderRepository.GetByIdOrDefaultAsync( request.Id );

                return Result<OrderDto>.Success( order.ToDto() );
            }
            catch ( Exception ex )
            {
                return Result<OrderDto>.Failure( ex.Message );
            }
        }
    }
}
