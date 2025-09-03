using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Warehouses;
using MusicStore.Presentation.Contracts.Warehouses.AddProductToWarehouse;
using MusicStore.Presentation.Contracts.Warehouses.CreateWarehouse;
using MusicStore.Presentation.Mappers.WarehouseMappingExtensions.AddProductToWarehouse;
using MusicStore.Presentation.Mappers.WarehouseMappingExtensions.CreateWarehouse;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class WarehousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehousesController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWarehouse( [FromBody] CreateWarehouseRequest request )
        {
            Result<Guid> createWarehouseResult = await _mediator.Send( request.ToCreateWarehouseCommand() );

            if ( createWarehouseResult.IsError )
            {
                return BadRequest( createWarehouseResult.Error );
            }

            return Ok( createWarehouseResult.ToCreateWarehouseResponse() );
        }

        [HttpPost( "add-product" )]
        public async Task<IActionResult> AddProductToWarehouse( [FromBody] AddProductToWarehouseRequest request )
        {
            Result<ProductWarehouse> addProductResult = await _mediator.Send( request.ToAddProductToWarehouseCommand() );

            if ( addProductResult.IsError )
            {
                return BadRequest( addProductResult.Error );
            }

            return Ok( addProductResult.ToAddProductToWarehouseResponse() );
        }
    }
}
