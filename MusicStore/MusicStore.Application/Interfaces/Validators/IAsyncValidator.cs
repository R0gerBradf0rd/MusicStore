using MusicStore.Application.ResultPattern;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IAsyncValidator<TRequest>
    {
        Task<Result> ValidateAsync( TRequest request );
    }
}
