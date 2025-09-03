namespace MusicStore.Presentation.Contracts.Reviews.DeleteReview
{
    public class DeleteReviewResponse
    {
        public Guid ReviewId { get; }

        public DeleteReviewResponse( Guid reviewId )
        {
            ReviewId = reviewId;
        }
    }
}
