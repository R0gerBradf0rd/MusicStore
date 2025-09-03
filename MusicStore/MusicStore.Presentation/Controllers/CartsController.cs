using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Carts;
using MusicStore.Presentation.Contracts.Carts.AddCartItem;
using MusicStore.Presentation.Contracts.Carts.GetCart;
using MusicStore.Presentation.Contracts.Carts.RemoveCartItem;
using MusicStore.Presentation.Contracts.Carts.SetCartItemQuantity;
using MusicStore.Presentation.Contracts.Carts.SetCartItemSelectionStatus;
using MusicStore.Presentation.Mappers.CartMappingExtensions.AddCartItem;
using MusicStore.Presentation.Mappers.CartMappingExtensions.GetCart;
using MusicStore.Presentation.Mappers.CartMappingExtensions.RemoveCartItem;
using MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemQuantity;
using MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemSelectionStatus;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost( "add-item" )]
        public async Task<IActionResult> AddItem( [FromBody] AddCartItemRequest request )
        {
            Result<CartItem> result = await _mediator.Send( request.ToAddCartItemToCartCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToAddCartItemResponse() );
        }

        [HttpDelete( "remove-item" )]
        public async Task<IActionResult> RemoveItem( [FromBody] RemoveCartItemRequest request )
        {
            Result<CartItem> result = await _mediator.Send( request.ToRemoveCartItemCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToRemoveCartItemResponse() );
        }

        [HttpPut( "set-item-quantity" )]
        public async Task<IActionResult> SetItemQuantity( [FromBody] SetCartItemQuantityRequest request )
        {
            Result<string> result = await _mediator.Send( request.ToSetCartItemQuantityCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToSetCartItemQuantityResponse() );
        }

        [HttpPut( "set-item-selection-status" )]
        public async Task<IActionResult> SetItemSelectionStatus( [FromBody] SetCartItemSelectionStatusRequest request )
        {
            Result<string> result = await _mediator.Send( request.ToSetCartItemSelectionStatusCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToSetCartItemSelectionStatusResponse() );
        }

        [HttpGet( "{id}" )]
        public async Task<IActionResult> GetCart( [FromRoute] Guid id )
        {
            var result = await _mediator.Send( new GetCartRequest( id ).ToGetCartQuery() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToGetCartResponse() );
        }
    }
}
