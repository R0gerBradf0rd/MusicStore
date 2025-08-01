using MusicStore.Application.Results;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IAsyncValidator<TRequest>
    {
        Task<Result> ValidateAsync( TRequest request );
    }
}
