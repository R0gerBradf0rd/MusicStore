using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : IAsyncValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandValidator( ICategoryRepository repository )
        {
            _repository = repository;
        }

        public async Task<Result> ValidateAsync( CreateCategoryCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Name ) )
            {
                return Result.Failure( "Название категории не может быть пустым!" );
            }

            bool isCategoryAlreadyExist = await _repository.ContainsAsync( c => c.Name == request.Name );

            if ( isCategoryAlreadyExist )
            {
                return Result.Failure( "Категория с таким названием уже существует!" );
            }

            return Result.Success();
        }
    }
}
