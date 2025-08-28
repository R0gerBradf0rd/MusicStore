namespace MusicStore.Application.Interfaces.Repository
{
    public interface IRepository<T> : IAddRepository<T>, IDeleteRepository<T>, IContainsAsyncRepository<T>
    {
    }
}
