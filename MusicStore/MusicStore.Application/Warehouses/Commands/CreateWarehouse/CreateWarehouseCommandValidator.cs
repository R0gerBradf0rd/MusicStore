using MusicStore.Application.Interfaces.Validators;
using MusicStore.Application.Results;
using MusicStore.Application.Warehouses.Repositories;

namespace MusicStore.Application.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandValidator : IAsyncValidator<CreateWarehouseCommand>
    {
        private readonly IWarehosueRepository _warehosueRepository;

        public CreateWarehouseCommandValidator( IWarehosueRepository warehosueRepository )
        {
            _warehosueRepository = warehosueRepository;
        }

        public async Task<Result> ValidateAsync( CreateWarehouseCommand request )
        {
            if ( string.IsNullOrWhiteSpace( request.Address ) )
            {
                return Result.Failure( "Адресс не может быть пустым!" );
            }

            bool isWarehouseAlreadyExist = await _warehosueRepository.ContainsAsync( w => w.Address == request.Address );

            if ( isWarehouseAlreadyExist )
            {
                return Result.Failure( "Склад с таким адресом уже существует!" );
            }

            return Result.Success();
        }
    }
}
