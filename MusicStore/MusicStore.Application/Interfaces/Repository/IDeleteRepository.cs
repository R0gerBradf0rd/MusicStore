namespace MusicStore.Application.Interfaces.Repository
{
    public interface IDeleteRepository<T>
    {
        Task DeleteAsync( T entity );
    }
}
