namespace MusicStore.Presentation.Contracts.Reviews.CreateReview
{
    public class CreateReviewRequest
    {
        public Guid ProductId { get; }

        public Guid UserId { get; }

        public int Rating { get; }

        public string Comment { get; }

        public CreateReviewRequest( Guid productId, Guid userId, int rating, string comment )
        {
            ProductId = productId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
        }
    }
}
