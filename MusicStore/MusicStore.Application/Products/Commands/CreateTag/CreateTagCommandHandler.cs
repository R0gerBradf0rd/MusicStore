using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.CreateTag
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, Result<Guid>>
    {
        private readonly ITagRepository _tagRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IAsyncValidator<CreateTagCommand> _asyncValidator;

        public CreateTagCommandHandler(
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateTagCommand> validator )
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = validator;
        }

        public async Task<Result<Guid>> Handle( CreateTagCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Tag tag = new Tag( request.Value );

                _tagRepository.Add( tag );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( tag.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
