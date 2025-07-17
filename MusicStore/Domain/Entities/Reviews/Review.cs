namespace MusicStore.Domain.Entities.Reviews
{
    public class Review
    {
        public Guid Id { get; }

        public Guid ProductId { get; }

        public Guid UserId { get; }

        public int Rating { get; }

        public string Comment { get; }
    }
}
// SetTheReviewRaiting
// SetTheReviewComment