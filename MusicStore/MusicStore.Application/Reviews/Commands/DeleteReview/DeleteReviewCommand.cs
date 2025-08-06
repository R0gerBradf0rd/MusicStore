using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Results;

namespace MusicStore.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : ICommand<Result<Guid>>
    {
        public Guid Id { get; }

        public DeleteReviewCommand( Guid id )
        {
            Id = id;
        }
    }
}
