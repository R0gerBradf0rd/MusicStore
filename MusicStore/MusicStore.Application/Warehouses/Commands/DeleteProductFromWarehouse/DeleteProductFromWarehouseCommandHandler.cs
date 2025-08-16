using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.DeleteProductFromWarehouse
{
    public class DeleteProductFromWarehouseCommandHandler : ICommandHandler<DeleteProductFromWarehouseCommand, Result<string>>
    {
        private readonly IWarehosueRepository _warehosueRepository;
        private readonly IProductWarehouseRepository _productWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<DeleteProductFromWarehouseCommand> _asyncValidator;

        public DeleteProductFromWarehouseCommandHandler(
            IWarehosueRepository warehosueRepository,
            IProductWarehouseRepository productWarehouseRepository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<DeleteProductFromWarehouseCommand> asyncValidator )
        {
            _warehosueRepository = warehosueRepository;
            _productWarehouseRepository = productWarehouseRepository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( DeleteProductFromWarehouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                Warehouse warehouse = await _warehosueRepository.GetByIdOrDefaultAsync( request.WarehouseId );
                ProductWarehouse productWarehouse = await _productWarehouseRepository.FindeAsync( pw => pw.ProductId == request.ProductId && pw.WarehouseId == request.WarehouseId );

                warehouse.DeleteProductFromWarehouse( productWarehouse );
                await _productWarehouseRepository.DeleteAsync( productWarehouse );
                _unitOfWork.CommitAsync();

                return Result<string>.Success( "Продукт удален со склада." );
            }
            catch ( Exception ex )
            {
                return Result<string>.Failure( ex.Message );
            }
        }
    }
}
