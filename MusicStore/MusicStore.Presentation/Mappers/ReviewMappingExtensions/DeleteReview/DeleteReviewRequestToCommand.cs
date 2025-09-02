using MusicStore.Application.Reviews.Commands.DeleteReview;

namespace MusicStore.Presentation.Mappers.ReviewMappingExtensions.DeleteReview
{
    public static class DeleteReviewRequestToCommand
    {
        public static DeleteReviewCommand ToDeleteReviewCommand( this Guid reviewId )
        {
            return new DeleteReviewCommand( reviewId );
        }
    }
}
