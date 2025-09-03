namespace MusicStore.Presentation.Contracts.Reviews.GetReview
{
    public class GetReviewResponse
    {
        public int Rating { get; }
        public string Comment { get; }

        public GetReviewResponse( int rating, string comment )
        {
            Rating = rating;
            Comment = comment;
        }
    }
}
