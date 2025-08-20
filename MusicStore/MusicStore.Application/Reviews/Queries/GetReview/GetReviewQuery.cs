using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Dtos;

namespace MusicStore.Application.Reviews.Queries.GetReview
{
    public class GetReviewQuery : IQuery<Result<ReviewDto>>
    {
        public Guid Id { get; }

        public GetReviewQuery( Guid id )
        {
            Id = id;
        }
    }
}
