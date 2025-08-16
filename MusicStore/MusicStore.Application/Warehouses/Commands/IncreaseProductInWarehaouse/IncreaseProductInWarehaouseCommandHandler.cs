using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.IncreaseProductInWarehaouse
{
    public class IncreaseProductInWarehaouseCommandHandler : ICommandHandler<IncreaseProductInWarehaouseCommand, Result<string>>
    {
        private readonly IProductWarehouseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<IncreaseProductInWarehaouseCommand> _asyncValidator;

        public IncreaseProductInWarehaouseCommandHandler(
            IProductWarehouseRepository repository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<IncreaseProductInWarehaouseCommand> asyncValidator )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( IncreaseProductInWarehaouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                ProductWarehouse productWarehouse = await _repository.FindeAsync( pw => pw.ProductId == request.ProductId && pw.WarehouseId == request.WarehouseId );

                productWarehouse.AddProductToWarehouse( request.WarehouseProductQuantity );
                await _unitOfWork.CommitAsync();

                return Result<string>.Success( $"Колличество товара увеличено на {request.WarehouseProductQuantity}." );
            }
            catch ( Exception ex )
            {
                return Result<string>.Failure( ex.Message );
            }
        }
    }
}
