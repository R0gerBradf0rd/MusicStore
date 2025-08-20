using MusicStore.Application.Interfaces.Query;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Dtos;
using MusicStore.Application.Reviews.Mappers;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Domain.Entities.Reviews;

namespace MusicStore.Application.Reviews.Queries.GetReview
{
    public class GetReviewQueryHandler : IQueryHandler<GetReviewQuery, Result<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IAsyncValidator<GetReviewQuery> _getReviewQueryValidator;

        public GetReviewQueryHandler(
            IReviewRepository reviewRepository,
            IAsyncValidator<GetReviewQuery> getReviewQueryValidator )
        {
            _reviewRepository = reviewRepository;
            _getReviewQueryValidator = getReviewQueryValidator;
        }

        public async Task<Result<ReviewDto>> Handle( GetReviewQuery request, CancellationToken cancellationToken )
        {
            Result validationResult = await _getReviewQueryValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<ReviewDto>.Failure( validationResult.Error );
            }
            try
            {
                Review review = await _reviewRepository.GetByIdOrDefaultAsync( request.Id );

                return Result<ReviewDto>.Success( review.ToDto() );
            }
            catch ( Exception ex )
            {
                return Result<ReviewDto>.Failure( ex.Message );
            }
        }
    }
}
