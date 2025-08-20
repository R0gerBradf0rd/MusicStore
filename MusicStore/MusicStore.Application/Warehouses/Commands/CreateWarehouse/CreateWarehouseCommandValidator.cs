using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;

namespace MusicStore.Application.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandValidator : IAsyncValidator<CreateWarehouseCommand>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public CreateWarehouseCommandValidator( IWarehouseRepository warehosueRepository )
        {
            _warehouseRepository = warehosueRepository;
        }

        public async Task<Result> ValidateAsync( CreateWarehouseCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Address ) )
            {
                return Result.Failure( "Адресс не может быть пустым!" );
            }

            bool isWarehouseAlreadyExists = await _warehouseRepository.ContainsAsync( w => w.Address == request.Address );

            if ( isWarehouseAlreadyExists )
            {
                return Result.Failure( "Склад с таким адресом уже существует!" );
            }

            return Result.Success();
        }
    }
}
