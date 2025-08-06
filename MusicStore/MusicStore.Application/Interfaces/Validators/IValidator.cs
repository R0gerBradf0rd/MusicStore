using MusicStore.Application.Results;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IValidator<TRequest>
    {
        Result Validate( TRequest value );
    }
}
