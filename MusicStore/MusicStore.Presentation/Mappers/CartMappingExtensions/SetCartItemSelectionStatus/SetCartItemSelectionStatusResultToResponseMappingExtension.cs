using MusicStore.Application.Results;
using MusicStore.Presentation.Contracts.Carts.SetCartItemSelectionStatus;

namespace MusicStore.Presentation.Mappers.CartMappingExtensions.SetCartItemSelectionStatus
{
    public static class SetCartItemSelectionStatusResultToResponseMappingExtension
    {
        public static SetCartItemSelectionStatusResponse ToSetCartItemSelectionStatusResponse( this Result<string> result )
        {
            return new SetCartItemSelectionStatusResponse( result.Value );
        }
    }
}
