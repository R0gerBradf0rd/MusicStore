namespace MusicStore.Application.Reviews.Dtos
{
    public class ReviewDto
    {
        public int Rating { get; }

        public string Comment { get; }

        public ReviewDto( int rating, string comment )
        {
            Rating = rating;
            Comment = comment;
        }
    }
}
