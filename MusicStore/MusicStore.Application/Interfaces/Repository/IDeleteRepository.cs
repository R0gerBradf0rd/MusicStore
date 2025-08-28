namespace MusicStore.Application.Interfaces.Repository
{
    public interface IDeleteRepository<T>
    {
        void Delete( T entity );
    }
}
