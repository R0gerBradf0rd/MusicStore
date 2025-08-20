using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Domain.Entities.Products;

namespace MusicStore.Application.Products.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<CreateCategoryCommand> _createCategoryCommandValidator;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<CreateCategoryCommand> createCategoryCommandValidator )
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _createCategoryCommandValidator = createCategoryCommandValidator;
        }

        public async Task<Result<Guid>> Handle( CreateCategoryCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _createCategoryCommandValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<Guid>.Failure( validationResult.Error );
            }
            try
            {
                Category category = new Category( request.Name );

                _categoryRepository.Add( category );
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success( category.Id );
            }
            catch ( Exception ex )
            {
                return Result<Guid>.Failure( ex.Message );
            }
        }
    }
}
