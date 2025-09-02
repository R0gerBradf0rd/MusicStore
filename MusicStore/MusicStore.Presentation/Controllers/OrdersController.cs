using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Orders.Dtos;
using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Orders.CreateOrder;
using MusicStore.Presentation.Mappers.OrdersMappingExtensions.CreateOrder;
using MusicStore.Presentation.Mappers.OrdersMappingExtensions.GetOrder;
using MusicStore.Presentation.Mappers.OrdersMappingExtensions.OrderStatusCommands;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost( "create" )]
        public async Task<IActionResult> CreateOrder( [FromBody] CreateOrderRequest request )
        {
            Result<Guid> result = await _mediator.Send( request.ToCreateOrderCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToCreateOrderResponse() );
        }

        [HttpGet( "{id:guid}" )]
        public async Task<IActionResult> GetOrder( Guid id )
        {
            Result<OrderDto> result = await _mediator.Send( id.ToGetOrderQuery() );

            if ( result.IsError )
                return NotFound( result.Error );

            return Ok( result.ToGetOrderResponse() );
        }

        [HttpPut( "{id:guid}/start-assembly" )]
        public async Task<IActionResult> SetStatusToStartAssembly( Guid id )
        {
            Result result = await _mediator.Send( id.ToSetStatusToStartAssemblyCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok();
        }

        [HttpPut( "{id:guid}/end-of-assembly" )]
        public async Task<IActionResult> SetStatusToEndOfAssembly( Guid id )
        {
            Result result = await _mediator.Send( id.ToSetStatusToEndOfAssemblyCommand() );

            if ( result.IsError )
                return BadRequest( result.Error );

            return Ok();
        }

        [HttpPut( "{id:guid}/shipping" )]
        public async Task<IActionResult> SetStatusToShipping( Guid id )
        {
            Result result = await _mediator.Send( id.ToSetStatusToShippingCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok();
        }

        [HttpPut( "{id:guid}/arrived" )]
        public async Task<IActionResult> SetStatusToArrived( Guid id )
        {
            Result result = await _mediator.Send( id.ToSetStatusToArrivedCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok();
        }
    }
}
