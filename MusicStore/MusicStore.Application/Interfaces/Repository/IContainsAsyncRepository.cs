using System.Linq.Expressions;

namespace MusicStore.Application.Interfaces.Repository
{
    public interface IContainsAsyncRepository<T>
    {
        Task<bool> ContainsAsync( Expression<Func<T, bool>> predicate );
    }
}
