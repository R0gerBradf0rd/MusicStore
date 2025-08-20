using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Repositories;

namespace MusicStore.Application.Reviews.Queries.GetReview
{
    public class GetReviewQueryValidator : IAsyncValidator<GetReviewQuery>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewQueryValidator( IReviewRepository reviewRepository )
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Result> ValidateAsync( GetReviewQuery request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isReviewExists = await _reviewRepository.ContainsAsync( r => r.Id == request.Id );

            if ( !isReviewExists )
            {
                return Result.Failure( "Данного отзыва несуществует!" );
            }

            return Result.Success();
        }
    }
}
