using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Reviews.Repositories;
using MusicStore.Domain.Entities.Reviews;

namespace MusicStore.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : ICommandHandler<CreateReviewCommand, Result<Guid>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateReviewCommand> _createReviewCommandValidator;

        public CreateReviewCommandHandler(
            IReviewRepository reviewRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateReviewCommand> validator )
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
            _createReviewCommandValidator = validator;
        }

        public async Task<Result<Guid>> Handle( CreateReviewCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = _createReviewCommandValidator.Validate( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Review review = new Review( request.ProductId, request.UserId, request.Rating, request.Comment );

                _reviewRepository.Add( review );
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
