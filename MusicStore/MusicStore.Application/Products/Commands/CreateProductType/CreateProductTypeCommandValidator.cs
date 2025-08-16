using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;

namespace MusicStore.Application.Products.Commands.CreateProductType
{
    public class CreateProductTypeCommandValidator : IAsyncValidator<CreateProductTypeCommand>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        private readonly ICategoryRepository _categoryRepository;

        public CreateProductTypeCommandValidator( IProductTypeRepository repository, ICategoryRepository categoryRepository )
        {
            _productTypeRepository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> ValidateAsync( CreateProductTypeCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Name ) )
            {
                return Result.Failure( "Название типа не может быть пустым!" );
            }
            if ( request.CategoryId == Guid.Empty )
            {
                return Result.Failure( "Id не может быть пустым!" );
            }

            bool isCategoryExist = await _categoryRepository.ContainsAsync( c => c.Id == request.CategoryId );

            if ( !isCategoryExist )
            {
                return Result.Failure( "Такой категории несуществует!" );
            }

            bool isProductTypeAlreadyExist = await _productTypeRepository.ContainsAsync( p => p.Name == request.Name );

            if ( isProductTypeAlreadyExist )
            {
                return Result.Failure( "Категория с таким названием уже существует!" );
            }

            return Result.Success();
        }
    }
}
