using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Reviews.DeleteReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.DeleteReview
{
    public static class DeleteReviewResultToResponse
    {
        public static DeleteReviewResponse ToDeleteReviewResponse( this Result<Guid> result )
        {
            return new DeleteReviewResponse( result.Value );
        }
    }
}
