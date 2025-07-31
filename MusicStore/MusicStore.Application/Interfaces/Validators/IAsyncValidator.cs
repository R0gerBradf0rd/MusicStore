using MusicStore.Application.Results;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IAsyncValidator<TRequest>
    {
        Task<Results.Result> ValidateAsync( TRequest request );
    }
}
