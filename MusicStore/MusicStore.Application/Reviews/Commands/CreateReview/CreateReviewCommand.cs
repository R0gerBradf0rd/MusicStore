using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : ICommand<Result<Guid>>
    {
        public Guid ProductId { get; }

        public Guid UserId { get; }

        public int Rating { get; }

        public string Comment { get; }

        public CreateReviewCommand( Guid productId, Guid userId, int rating, string comment )
        {
            ProductId = productId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
        }
    }
}
