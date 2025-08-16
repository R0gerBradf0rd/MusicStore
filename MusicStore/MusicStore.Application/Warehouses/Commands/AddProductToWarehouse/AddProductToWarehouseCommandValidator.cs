using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Products.Repositories;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;

namespace MusicStore.Application.Warehouses.Commands.AddProductToWarehouse
{
    public class AddProductToWarehouseCommandValidator : IAsyncValidator<AddProductToWarehouseCommand>
    {
        private readonly IWarehosueRepository _warehosueRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public AddProductToWarehouseCommandValidator(
            IWarehosueRepository warehosueRepository,
            IProductRepository productRepository,
            IProductWarehouseRepository productWarehouseRepository )
        {
            _warehosueRepository = warehosueRepository;
            _productRepository = productRepository;
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task<Result> ValidateAsync( AddProductToWarehouseCommand request )
        {
            if ( request.ProductId == Guid.Empty )
            {
                return Result.Failure( "Id продукта не может быть пустым!" );
            }
            if ( request.WarehouseId == Guid.Empty )
            {
                return Result.Failure( "Id склада не может быть пустым!" );
            }
            if ( request.WarehouseProductQuantity < 0 )
            {
                return Result.Failure( "Количество товара не может быть отрицательным!" );
            }

            bool isProductExist = await _productRepository.ContainsAsync( p => p.Id == request.ProductId );
            bool isWarehouseExist = await _warehosueRepository.ContainsAsync( w => w.Id == request.WarehouseId );

            if ( !isProductExist )
            {
                return Result.Failure( "Продукта с таким Id несуществует!" );
            }
            if ( !isWarehouseExist )
            {
                return Result.Failure( "Склада с таким Id несуществует!" );
            }

            bool isWarehouseProductAlreadyExist = await _productWarehouseRepository.ContainsAsync( pw => pw.WarehouseId == request.WarehouseId && pw.ProductId == request.ProductId );

            if ( isWarehouseProductAlreadyExist )
            {
                return Result.Failure( "Такой продукт уже есть на этом складе!" );
            }

            return Result.Success();
        }
    }
}
