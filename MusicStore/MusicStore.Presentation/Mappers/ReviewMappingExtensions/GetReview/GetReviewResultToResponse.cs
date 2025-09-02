using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Dtos;
using MusicStore.Presentation.Contracts.Reviews.GetReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.GetReview
{
    public static class GetReviewResultToResponse
    {
        public static GetReviewResponse ToGetReviewResponse( this Result<ReviewDto> result )
        {
            return new GetReviewResponse( result.Value.Rating, result.Value.Comment );
        }
    }
}
