using MusicStore.Application.Reviews.Queries.GetReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.GetReview
{
    public static class GetReviewRequestToQuery
    {
        public static GetReviewQuery ToGetReviewQuery( this Guid reviewId )
        {
            return new GetReviewQuery( reviewId );
        }
    }
}
