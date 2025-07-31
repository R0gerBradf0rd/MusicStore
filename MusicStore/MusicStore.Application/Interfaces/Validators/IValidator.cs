using MusicStore.Application.ResultPattern;

namespace MusicStore.Application.Interfaces.Validators
{
    public interface IValidator<T>
    {
        Result Validate( T value );
    }
}
