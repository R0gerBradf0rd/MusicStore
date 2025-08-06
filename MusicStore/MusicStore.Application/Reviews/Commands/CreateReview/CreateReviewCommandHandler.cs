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
        private readonly IReviewRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<CreateReviewCommand> _validator;

        public CreateReviewCommandHandler(
            IReviewRepository repository,
            IUnitOfWork unitOfWork,
            IValidator<CreateReviewCommand> validator )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle( CreateReviewCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = _validator.Validate( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Review review = new Review( request.ProductId, request.UserId, request.Rating, request.Comment );
                _repository.Add( review );
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
