using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Domain.Entities.Reviews;

namespace MusicStore.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : ICommandHandler<DeleteReviewCommand, Result<Guid>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<DeleteReviewCommand> _deleteReviewCommandValidator;

        public DeleteReviewCommandHandler(
            IReviewRepository reviewRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<DeleteReviewCommand> deleteReviewCommandValidator )
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
            _deleteReviewCommandValidator = deleteReviewCommandValidator;
        }

        public async Task<Result<Guid>> Handle( DeleteReviewCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _deleteReviewCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Review review = await _reviewRepository.GetByIdOrDefaultAsync( request.Id );

                _reviewRepository.Delete( review );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( review.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
