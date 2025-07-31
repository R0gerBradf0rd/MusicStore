using MusicStore.Application.Results;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IValidator<T>
    {
        Results.Result Validate( T value );
    }
}
