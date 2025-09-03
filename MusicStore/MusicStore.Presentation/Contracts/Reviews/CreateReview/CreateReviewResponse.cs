namespace MusicStore.Presentation.Contracts.Reviews.CreateReview
{
    public class CreateReviewResponse
    {
        public Guid ReviewId { get; }

        public CreateReviewResponse( Guid reviewId )
        {
            ReviewId = reviewId;
        }
    }
}
