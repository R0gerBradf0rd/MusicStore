namespace MusicStore.Application.Interfaces.Repository
{
    public interface IUpdateRepository<T>
    {
        Task UpdateAsync( T entity );
    }
}
