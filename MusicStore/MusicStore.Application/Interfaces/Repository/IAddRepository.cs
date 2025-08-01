namespace MusicStore.Application.Interfaces.Repository
{
    public interface IAddRepository<T>
    {
        void Add( T entity );
    }
}
