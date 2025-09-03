using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Reviews.CreateReview;
using MusicStore.Presentation.Mappers.ReviewMappingExtensions.CreateReview;
using MusicStore.Presentation.Mappers.ReviewMappingExtensions.DeleteReview;
using MusicStore.Presentation.Mappers.ReviewMappingExtensions.GetReview;

namespace MusicStore.Presentation.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController( IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview( [FromBody] CreateReviewRequest request )
        {
            Result<Guid> createReviewResult = await _mediator.Send( request.ToCreateReviewCommand() );

            if ( createReviewResult.IsError )
            {
                return BadRequest( createReviewResult.Error );
            }

            return Ok( createReviewResult.ToCreateReviewResponse() );
        }

        [HttpDelete( "{id:guid}" )]
        public async Task<IActionResult> DeleteReview( Guid id )
        {
            Result<Guid> deleteReviewResult = await _mediator.Send( id.ToDeleteReviewCommand() );

            if ( deleteReviewResult.IsError )
            {
                return BadRequest( deleteReviewResult.Error );
            }

            return Ok( deleteReviewResult.ToDeleteReviewResponse() );
        }

        [HttpGet( "{id:guid}" )]
        public async Task<IActionResult> GetReviewById( Guid id )
        {
            var result = await _mediator.Send( id.ToGetReviewQuery() );

            if ( result.IsError )
            {
                return BadRequest( result.Error );
            }

            return Ok( result.ToGetReviewResponse() );
        }
    }
}
