using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Repositories;

namespace MusicStore.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator : IAsyncValidator<DeleteReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewCommandValidator( IReviewRepository reviewRepository )
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Result> ValidateAsync( DeleteReviewCommand request )
        {
            if ( request.Id == Guid.Empty )
            {
                return Result.Failure( "Id отзыва не может быть пустым!" );
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
