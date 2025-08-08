using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;

namespace MusicStore.Application.Warehouses.Commands.TakeProductFromWarehouse
{
    public class TakeProductFromWarehouseCommandValidator : IAsyncValidator<TakeProductFromWarehouseCommand>
    {
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public TakeProductFromWarehouseCommandValidator( IProductWarehouseRepository productWarehouseRepository )
        {
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task<Result> ValidateAsync( TakeProductFromWarehouseCommand request )
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

            bool isWarehouseProductExist = await _productWarehouseRepository.ContainsAsync( pw => pw.WarehouseId == request.WarehouseId && pw.ProductId == request.ProductId );

            if ( !isWarehouseProductExist )
            {
                return Result.Failure( "Такого продукта нет на этом складе!" );
            }

            return Result.Success();
        }
    }
}
