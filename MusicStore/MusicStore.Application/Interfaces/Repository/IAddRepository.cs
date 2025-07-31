namespace MusicStore.Application.Interfaces.Repository
{
    public interface IAddRepository<T>
    {
        Task AddAsync( T entity );
    }
}
