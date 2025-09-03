using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Products.Dtos;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;
using MusicStore.Presentation.Contracts.Products.AddProductTag;
using MusicStore.Presentation.Contracts.Products.CreateCategory;
using MusicStore.Presentation.Contracts.Products.CreateProduct;
using MusicStore.Presentation.Contracts.Products.CreateProductType;
using MusicStore.Presentation.Contracts.Products.CreateTag;
using MusicStore.Presentation.Contracts.Products.RemoveProductTag;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.AddProductTag;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateCategory;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProduct;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateProductType;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.CreateTag;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.GetProduct;
using MusicStore.Presentation.Mappers.ProductMappingExtensions.RemoveProductTag;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost( "add-tag" )]
        public async Task<IActionResult> AddProductTag( [FromBody] AddProductTagRequest request )
        {
            Result<ProductTag> result = await _mediator.Send( request.ToAddProductTagCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToAddProductTagResponse() );
        }

        [HttpPost( "create-category" )]
        public async Task<IActionResult> CreateCategory( [FromBody] CreateCategoryRequest request )
        {
            Result<Guid> result = await _mediator.Send( request.ToCreateCategoryCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToCreateCategoryResponse() );
        }

        [HttpPost( "create-product" )]
        public async Task<IActionResult> CreateProduct( [FromBody] CreateProductRequest request )
        {
            Result<Guid> result = await _mediator.Send( request.ToCreateProductCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToCreateProductResponse() );
        }

        [HttpPost( "create-product-type" )]
        public async Task<IActionResult> CreateProductType( [FromBody] CreateProductTypeRequest request )
        {
            Result<Guid> result = await _mediator.Send( request.ToCreateProductTypeCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToCreateProductTypeResponse() );
        }

        [HttpPost( "create-tag" )]
        public async Task<IActionResult> CreateTag( [FromBody] CreateTagRequest request )
        {
            Result<Guid> result = await _mediator.Send( request.ToCreateTagCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToCreateTagResponse() );
        }

        [HttpDelete( "remove-product-tag" )]
        public async Task<IActionResult> RemoveProductTag( [FromBody] RemoveProductTagRequest request )
        {
            Result<ProductTag> result = await _mediator.Send( request.ToRemoveProductTagCommand() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToRemoveProductTagResponse() );
        }

        [HttpGet( "{id:guid}" )]
        public async Task<IActionResult> GetProductById( Guid id )
        {
            Result<ProductDto> result = await _mediator.Send( id.ToGetProductQuery() );

            if ( result.IsError )
            {
                return NotFound( result.Error );
            }

            return Ok( result.ToGetProductResponse() );
        }
    }
}
