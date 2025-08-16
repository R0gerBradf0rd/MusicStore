using MusicStore.Application.Interfaces.Command;
using MusicStore.Application.Interfaces.UnitOfWork;
using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;
using MusicStore.Domain.Entities.Warehouses;

namespace MusicStore.Application.Warehouses.Commands.DecriseProductInWarehouse
{
    public class DecriseProductInWarehouseCommandHandler : ICommandHandler<DecriseProductInWarehouseCommand, Result<string>>
    {
        private readonly IProductWarehouseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncValidator<DecriseProductInWarehouseCommand> _asyncValidator;

        public DecriseProductInWarehouseCommandHandler(
            IProductWarehouseRepository repository,
            IUnitOfWork unitOfWork,
            IAsyncValidator<DecriseProductInWarehouseCommand> asyncValidator )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _asyncValidator = asyncValidator;
        }

        public async Task<Result<string>> Handle( DecriseProductInWarehouseCommand request, CancellationToken cancellationToken )
        {
            Result validationResult = await _asyncValidator.ValidateAsync( request );
            if ( validationResult.IsError )
            {
                return Result<string>.Failure( validationResult.Error );
            }
            try
            {
                ProductWarehouse productWarehouse = await _repository.FindeAsync( pw => pw.ProductId == request.ProductId && pw.WarehouseId == request.WarehouseId );

                productWarehouse.TakeProductFromWarehouse( request.WarehouseProductQuantity );
                await _unitOfWork.CommitAsync();

                return Result<string>.Success( $"Колличество товара уменьшено на {request.WarehouseProductQuantity}." );
            }
            catch ( Exception ex )
            {
                return Result<string>.Failure( ex.Message );
            }
        }
    }
}
