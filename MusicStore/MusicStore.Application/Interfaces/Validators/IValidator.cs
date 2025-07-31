using MusicStore.Application.Results;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IValidator<T>
    {
        Result Validate( T value );
    }
}
