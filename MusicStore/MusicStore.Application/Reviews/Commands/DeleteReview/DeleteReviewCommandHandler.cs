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
        private readonly IReviewRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<DeleteReviewCommand> _asyncValidator;

        public DeleteReviewCommandHandler(
            IReviewRepository repository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<DeleteReviewCommand> asyncValidator )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<Guid>> Handle( DeleteReviewCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Review review = await _repository.GetByIdOrDefaultAsync( request.Id );
                await _repository.DeleteAsync( review );
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
